using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Roles;
using Data.Shop.UserRoles;
using Data.Shop.Users;
using Domain.Shop.Roles;
using Domain.Shop.UserRoles;
using Domain.Shop.Users;
using Facade.Shop.UserRoles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.UserRoles
{
    public class UserRolesPage : ViewPage<IUserRolesRepository, UserRole, UserRoleView, UserRoleData>
    {
        public UserRolesPage(
            IUserRolesRepository repository,
            IUsersRepository usersRepository,
            IRolesRepository rolesRepository) : base(repository, PagesNames.UserRoles)
        { 
            Users = NewUsersList<User, UserData>(usersRepository); 
            Roles = NewItemsList<Role, RoleData>(rolesRepository);
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

        public string GetUserName(string itemUserId) => GetItemName(Users, itemUserId);

        public string GetRoleName(string itemRoleId) => GetItemName(Roles, itemRoleId);
        
        private bool IsUser() => FixedFilter == GetMember.Name<UserRoleView>(x => x.UserId);
        
        private bool IsRole() => FixedFilter == GetMember.Name<UserRoleView>(x => x.RoleId);

        protected internal override string GetPageSubtitle()
        {
            if (IsUser())
            {
                return $"{GetUserName(FixedValue)}";
            }
            else if (IsRole())
            {
                return $"{GetRoleName(FixedValue)}";
            }
            else
            {
                return "Määramata alalehe pealkiri";
            }
        }
    }
}
