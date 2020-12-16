using Aids.Methods;
using Data.Shop.Roles;
using Domain.Shop.Roles;

namespace Facade.Shop.Roles
{
    public static class RoleViewFactory
    {
        public static Role Create(RoleView view)
        {
            var roleData = new RoleData();
            Copy.Members(view, roleData);
            
            return new Role(roleData);
        }
        public static RoleView Create(Role role)
        {
            var view = new RoleView();
            Copy.Members(role.Data, view);

            return view;
        }
    }
}
