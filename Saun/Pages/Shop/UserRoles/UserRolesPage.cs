﻿using System;
using System.Collections.Generic;
using Data.Shop.UserRoles;
using Domain.Shop.UserRoles;
using Facade.Shop.UserRoles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.UserRoles
{
    public class UserRolesPage : ViewPage<IUserRolesRepository, UserRole, UserRoleView, UserRoleData>
    {
        public UserRolesPage(IUserRolesRepository repository) : base(repository, PagesNames.UserRoles)
        {
        }

        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<SelectListItem> Roles { get; set; }

        protected internal override UserRole ToObject(UserRoleView view) => UserRoleViewFactory.Create(view);

        protected internal override UserRoleView ToView(UserRole obj) => UserRoleViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.UserRoles, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new UserRoleView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public string GetUserName(string itemUserId)
        {
            throw new NotImplementedException();
        }

        public string GetRoleName(string itemRoleId)
        {
            throw new NotImplementedException();
        }
    }
}
