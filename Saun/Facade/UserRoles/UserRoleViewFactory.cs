using Aids.Methods;
using Data.UserRoles;
using Domain.UserRoles;

namespace Facade.UserRoles
{
    public static class UserRoleViewFactory
    {
        public static UserRole Create(UserRoleView view)
        {
            var UserRoleData = new UserRoleData();
            Copy.Members(view, UserRoleData);
            
            return new UserRole(UserRoleData);
        }
        public static UserRoleView Create(UserRole UserRole)
        {
            var view = new UserRoleView();
            Copy.Members(UserRole.Data, view);

            return view;
        }
    }
}
