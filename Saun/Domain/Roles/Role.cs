using Data.Roles;
using Domain.Abstractions;

namespace Domain.Roles
{
    public sealed class Role : DefinedEntity<RoleData>
    {
        public Role() : this(null)
        {
            
        }

        public Role(RoleData data) : base(data)
        {
            
        }
    }
}