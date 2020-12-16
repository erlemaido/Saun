using Data.Shop.Roles;
using Domain.Abstractions;

namespace Domain.Shop.Roles
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