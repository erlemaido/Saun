using Aids.Methods;
using Data.Users;
using Domain.Users;

namespace Facade.Users
{
    public static class UserViewFactory
    {
        public static User Create(UserView view)
        {
            var UserData = new UserData();
            Copy.Members(view, UserData);
            
            return new User(UserData);
        }
        public static UserView Create(User User)
        {
            var view = new UserView();
            Copy.Members(User.Data, view);

            return view;
        }
    }
}
