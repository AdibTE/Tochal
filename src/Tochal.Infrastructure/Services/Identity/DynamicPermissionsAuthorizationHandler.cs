﻿using Tochal.Core.Common.GuardToolkit;
using Tochal.Infrastructure.Services.Contracts.Identity; 
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Threading.Tasks;
using System;
using DNTCommon.Web.Core;
using Microsoft.Extensions.DependencyInjection;
using Tochal.Core.DomainModels.ViewModel.Identity;

namespace Tochal.Infrastructure.Services.Identity
{
    public class DynamicPermissionRequirement : IAuthorizationRequirement
    {
    }

    public class DynamicPermissionsAuthorizationHandler : AuthorizationHandler<DynamicPermissionRequirement>
    {
        private readonly ISecurityTrimmingService _securityTrimmingService;

        public DynamicPermissionsAuthorizationHandler(ISecurityTrimmingService securityTrimmingService)
        {
            _securityTrimmingService = securityTrimmingService;
            _securityTrimmingService.CheckArgumentIsNull(nameof(_securityTrimmingService));
        }

        protected override async Task HandleRequirementAsync(
             AuthorizationHandlerContext context,
             DynamicPermissionRequirement requirement)
        {
            var mvcContext = context.Resource as AuthorizationFilterContext;
            if (mvcContext == null)
            {
                return;
            }

            var actionDescriptor = mvcContext.ActionDescriptor;

            actionDescriptor.RouteValues.TryGetValue("area", out var areaName);
            var area = string.IsNullOrWhiteSpace(areaName) ? string.Empty : areaName;

            actionDescriptor.RouteValues.TryGetValue("controller", out var controllerName);
            var controller = string.IsNullOrWhiteSpace(controllerName) ? string.Empty : controllerName;

            actionDescriptor.RouteValues.TryGetValue("action", out var actionName);
            var action = string.IsNullOrWhiteSpace(actionName) ? string.Empty : actionName;

            // How to access form values from an AuthorizationHandler
            var request = mvcContext.HttpContext.Request;
            if (request.Method.Equals("post", StringComparison.OrdinalIgnoreCase))
            {
                if (request.IsAjaxRequest() && request.ContentType.Contains("application/json"))
                {
                    var httpRequestInfoService = mvcContext.HttpContext.RequestServices.GetService<IHttpRequestInfoService>();
                    var model = await httpRequestInfoService.DeserializeRequestJsonBodyAsAsync<RoleViewModel>();
                    if (model != null)
                    {

                    }
                }
                else
                {
                    foreach (var item in request.Form)
                    {
                        var formField = item.Key;
                        var formFieldValue = item.Value;
                    }
                }
            }

            if (_securityTrimmingService.CanCurrentUserAccess(area, controller, action))
            {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }
        }
    }
}