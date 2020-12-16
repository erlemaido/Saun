using Data.Shop.Users;
using Domain.Abstractions;

namespace Domain.Shop.Users
{
    public sealed class User : UniqueEntity<UserData>
    {
        public User() : this(null)
        {
            
        }

        public User(UserData data) : base(data)
        {
            
        }
    }
}