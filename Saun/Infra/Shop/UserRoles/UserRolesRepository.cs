using Data.Shop.UserRoles;
using Domain.Shop.UserRoles;
using Infra.Abstractions;

namespace Infra.Shop.UserRoles
{
    public sealed class UserRolesRepository : UniqueEntityRepository<UserRole, UserRoleData>, IUserRolesRepository
    {
        protected internal override UserRole ToDomainObject(UserRoleData data) => new UserRole(data);

        public UserRolesRepository(SaunaDbContext context) : base(context, context.UserRoles)
        {
        }
    }
}