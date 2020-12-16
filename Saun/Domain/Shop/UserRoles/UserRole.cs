using Data.Shop.UserRoles;
using Domain.Abstractions;

namespace Domain.Shop.UserRoles
{
    public sealed class UserRole : UniqueEntity<UserRoleData>
    {
        public UserRole() : this(null)
        {
            
        }

        public UserRole(UserRoleData data) : base(data)
        {
            
        }
    }
}