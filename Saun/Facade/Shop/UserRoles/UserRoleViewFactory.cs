using Aids.Methods;
using Data.Shop.UserRoles;
using Domain.Shop.UserRoles;

namespace Facade.Shop.UserRoles
{
    public static class UserRoleViewFactory
    {
        public static UserRole Create(UserRoleView view)
        {
            var userRoleData = new UserRoleData();
            Copy.Members(view, userRoleData);
            
            return new UserRole(userRoleData);
        }
        public static UserRoleView Create(UserRole userRole)
        {
            var view = new UserRoleView();
            Copy.Members(userRole.Data, view);

            return view;
        }
    }
}
