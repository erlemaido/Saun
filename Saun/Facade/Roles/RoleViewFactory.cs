using Aids.Methods;
using Data.Roles;
using Domain.Roles;

namespace Facade.Roles
{
    public static class RoleViewFactory
    {
        public static Role Create(RoleView view)
        {
            var RoleData = new RoleData();
            Copy.Members(view, RoleData);
            
            return new Role(RoleData);
        }
        public static RoleView Create(Role Role)
        {
            var view = new RoleView();
            Copy.Members(Role.Data, view);

            return view;
        }
    }
}
