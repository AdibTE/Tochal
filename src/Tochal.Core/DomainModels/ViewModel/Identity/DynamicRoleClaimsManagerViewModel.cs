﻿using System.Collections.Generic;
using Tochal.Core.DomainModels.Entity.Identity;
using DNTCommon.Web.Core;

namespace Tochal.Core.DomainModels.ViewModel.Identity
{
    public class DynamicRoleClaimsManagerViewModel
    {
        public string[] ActionIds { set; get; }

        public int RoleId { set; get; }

        public Role RoleIncludeRoleClaims { set; get; }

        public ICollection<MvcControllerViewModel> SecuredControllerActions { set; get; }
    }
}