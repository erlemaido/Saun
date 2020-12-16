using Data.Users;
using Domain.Abstractions;

namespace Domain.Users
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