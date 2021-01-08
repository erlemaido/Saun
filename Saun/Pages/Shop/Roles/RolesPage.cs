using System;
using Data.Shop.Roles;
using Domain.Shop.Roles;
using Facade.Shop.Roles;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Roles
{
    public sealed class RolesPage : ViewPage<IRolesRepository, Role, RoleView, RoleData>
    {
        public RolesPage(IRolesRepository repository) : base(repository, PagesNames.Roles)
        {
        }

        protected internal override Role ToObject(RoleView view) => RoleViewFactory.Create(view);

        protected internal override RoleView ToView(Role obj) => RoleViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Roles, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new RoleView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}
