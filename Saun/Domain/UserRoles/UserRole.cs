using Data.UserRoles;
using Domain.Abstractions;

namespace Domain.UserRoles
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