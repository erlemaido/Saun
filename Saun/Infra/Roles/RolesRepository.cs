using Data.Roles;
using Domain.Roles;
using Infra.Abstractions;

namespace Infra.Roles
{
    public sealed class RolesRepository : UniqueEntityRepository<Role, RoleData>, IRolesRepository
    {
        protected internal override Role ToDomainObject(RoleData data) => new Role(data);

        public RolesRepository(SaunaDbContext context) : base(context, context.Roles)
        {
        }
    }
}