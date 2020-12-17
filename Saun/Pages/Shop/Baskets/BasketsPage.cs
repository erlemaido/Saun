using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Baskets;
using Data.Shop.Users;
using Domain.Shop.Baskets;
using Domain.Shop.Users;
using Facade.Shop.Baskets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Baskets
{
   public class BasketsPage : ViewPage<IBasketsRepository, Basket, BasketView, BasketData>
    {
        public BasketsPage(
            IBasketsRepository repository,
            IUsersRepository usersRepository) : base(repository, PagesNames.Baskets)
        {
            Users = NewUsersList<User, UserData>(usersRepository);
        }
        public IEnumerable<SelectListItem> Users { get; set; }

        protected internal override Basket ToObject(BasketView view) => BasketViewFactory.Create(view);
        
        protected internal override BasketView ToView(Basket obj) => BasketViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Baskets, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new BasketView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public string GetUserName(string itemUserId) => GetItemName(Users, itemUserId);
        private bool IsUser() => FixedFilter == GetMember.Name<BasketView>(x => x.UserId);

        protected internal override string GetPageSubtitle()
        {
            if (IsUser())
            {
                return $"{GetUserName(FixedValue)}";
            }
            else
            {
                return "Määramata alalehe pealkiri";
            }
        }
    }
}