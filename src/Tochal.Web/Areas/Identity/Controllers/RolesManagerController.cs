﻿using Tochal.Core.Common.GuardToolkit;
using Tochal.Core.Common.IdentityToolkit;



using Tochal.Core.DomainModels.ViewModel.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using System.Threading.Tasks;

using DNTBreadCrumb.Core;
using DNTCommon.Web.Core;
using Tochal.Infrastructure.Services.Identity;
using Tochal.Infrastructure.Services.Contracts.Identity;
using Tochal.Core.DomainModels.Entity.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Tochal.Web.Helpers;
using Tochal.Core.DomainModels.SSOT;

namespace Tochal.Web.Areas.Identity.Controllers
{
    [Authorize(Policy = ConstantPolicies.DynamicPermission)]
    [Area(AreaConstants.IdentityArea)]
    [BreadCrumb(Title = "مدیریت نقش‌ها", UseDefaultRouteUrl = true, Order = 0)]
    [DisplayName("مدیریت نقش‌ها")]
    public class RolesManagerController : Controller
    {
        private const string RoleNotFound = "نقش درخواستی یافت نشد.";
        private const int DefaultPageSize = 7;

        private readonly IApplicationRoleManager _roleManager;

        public RolesManagerController(IApplicationRoleManager roleManager)
        {
            _roleManager = roleManager;
            _roleManager.CheckArgumentIsNull(nameof(_roleManager));
        }

        [BreadCrumb(Title = "ایندکس", Order = 1)]
        [DisplayName("لیست نقش ها")]
        [GroupingDashboard(GroupingDashboardSSOT.Management)]
        public IActionResult Index()
        {
            var roles = _roleManager.GetAllCustomRolesAndUsersCountList();
            return View(roles);
        }

        [AjaxOnly]
        public async Task<IActionResult> RenderRole([FromBody]ModelIdViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model?.Id))
            {
                return PartialView("_Create");
            }

            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ModelState.AddModelError("", RoleNotFound);
                return PartialView("_Create");
            }
            return PartialView("_Create", model: new RoleViewModel { Id = role.Id.ToString(), Name = role.Name });
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ویرایش")]

        public async Task<IActionResult> EditRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(model.Id);
                if (role == null)
                {
                    ModelState.AddModelError("", RoleNotFound);
                }
                else
                {
                    role.Name = model.Name;
                    var result = await _roleManager.UpdateAsync(role);
                    if (result.Succeeded)
                    {
                        return Json(new { success = true });
                    }
                    ModelState.AddErrorsFromResult(result);
                }
            }
            return PartialView("_Create", model: model);
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("ایجاد")]
        public async Task<IActionResult> AddRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _roleManager.CreateAsync(new Role(model.Name));
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                ModelState.AddErrorsFromResult(result);
            }
            return PartialView("_Create", model: model);
        }

        [AjaxOnly]
        public async Task<IActionResult> RenderDeleteRole([FromBody]ModelIdViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model?.Id))
            {
                return PartialView("_Delete");
            }

            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ModelState.AddModelError("", RoleNotFound);
                return PartialView("_Delete");
            }
            return PartialView("_Delete", model: new RoleViewModel { Id = role.Id.ToString(), Name = role.Name });
        }

        [AjaxOnly]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [DisplayName("حذف")]
        public async Task<IActionResult> Delete(RoleViewModel model)
        {
            var role = await _roleManager.FindByIdAsync(model.Id);
            if (role == null)
            {
                ModelState.AddModelError("", RoleNotFound);
            }
            else
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Json(new { success = true });
                }
                ModelState.AddErrorsFromResult(result);
            }
            return PartialView("_Delete", model: model);
        }

        [BreadCrumb(Title = "لیست کاربران دارای نقش", Order = 1)]
        public async Task<IActionResult> UsersInRole(int? id, int? page = 1, string field = "Id", SortOrder order = SortOrder.Ascending)
        {
            if (id == null)
            {
                return View("Error");
            }

            var model = await _roleManager.GetPagedApplicationUsersInRoleListAsync(
                roleId: id.Value,
                pageNumber: page.Value - 1,
                recordsPerPage: DefaultPageSize,
                sortByField: field,
                sortOrder: order,
                showAllUsers: true);

            model.CurrentPage = page.Value;
            model.ItemsPerPage = DefaultPageSize;
            model.ShowFirstLast = true;

            if (HttpContext.Request.IsAjaxRequest())
            {
                return PartialView("~/Areas/Identity/Views/UsersManager/_UsersList.cshtml", model);
            }
            return View(model);
        }
    }
}