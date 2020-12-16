using Data.Shop.Users;
using Domain.Shop.Users;
using Infra.Abstractions;

namespace Infra.Shop.Users
{
    public sealed class UsersRepository : UniqueEntityRepository<User, UserData>, IUsersRepository
    {
        protected internal override User ToDomainObject(UserData data) => new User(data);

        public UsersRepository(SaunaDbContext context) : base(context, context.Users)
        {
        }
    }
}