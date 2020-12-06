using System;
using Data.Users;
using Domain.Users;
using Facade.Users;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Users
{
    public class UsersPage : ViewPage<IUsersRepository, User, UserView, UserData>
    {
        public UsersPage(IUsersRepository repository) : base(repository, PagesNames.Users)
        {
        }

        protected internal override User ToObject(UserView view) => UserViewFactory.Create(view);

        protected internal override UserView ToView(User obj) => UserViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Users, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new UserView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}
