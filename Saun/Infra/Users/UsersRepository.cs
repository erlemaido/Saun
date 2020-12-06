using Data.Users;
using Domain.Users;
using Infra.Abstractions;

namespace Infra.Users
{
    public sealed class UsersRepository : UniqueEntityRepository<User, UserData>, IUsersRepository
    {
        protected internal override User ToDomainObject(UserData data) => new User(data);

        public UsersRepository(SaunaDbContext context) : base(context, context.Users)
        {
        }
    }
}