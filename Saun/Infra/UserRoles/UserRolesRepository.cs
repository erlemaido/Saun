using Data.UserRoles;
using Domain.UserRoles;
using Infra.Abstractions;

namespace Infra.UserRoles
{
    public sealed class UserRolesRepository : UniqueEntityRepository<UserRole, UserRoleData>, IUserRolesRepository
    {
        protected internal override UserRole ToDomainObject(UserRoleData data) => new UserRole(data);

        public UserRolesRepository(SaunaDbContext context) : base(context, context.UserRoles)
        {
        }
    }
}