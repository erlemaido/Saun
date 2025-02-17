﻿using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.People;
using Data.Shop.Users;
using Domain.Shop.People;
using Domain.Shop.Users;
using Facade.Shop.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Users
{
    public sealed class UsersPage : ViewPage<IUsersRepository, User, UserView, UserData>
    {
        public UsersPage(
            IUsersRepository repository,
            IPeopleRepository peopleRepository) : base(repository, PagesNames.Users)
        {
            People = NewPeopleList<Person, PersonData>(peopleRepository);
        }

        public IEnumerable<SelectListItem> People { get; set; }

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

        public string GetPersonName(string itemPersonId) => GetItemName(People, itemPersonId);
    }
}
