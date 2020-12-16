using Aids.Methods;
using Data.Shop.Users;
using Domain.Shop.Users;

namespace Facade.Shop.Users
{
    public static class UserViewFactory
    {
        public static User Create(UserView view)
        {
            var userData = new UserData();
            Copy.Members(view, userData);
            
            return new User(userData);
        }
        public static UserView Create(User user)
        {
            var view = new UserView();
            Copy.Members(user.Data, view);

            return view;
        }
    }
}
