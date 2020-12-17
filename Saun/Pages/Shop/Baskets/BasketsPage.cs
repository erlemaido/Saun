using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Baskets;
using Data.Shop.People;
using Data.Shop.Users;
using Domain.Shop.Baskets;
using Domain.Shop.People;
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
            IPeopleRepository peopleRepository) : base(repository, PagesNames.Baskets)
        {
            People = NewPeopleList<Person, PersonData>(peopleRepository);
        }
        public IEnumerable<SelectListItem> People { get; set; }

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

        public string GetPersonName(string itemPersonId) => GetItemName(People, itemPersonId);
        private bool IsPerson() => FixedFilter == GetMember.Name<BasketView>(x => x.PersonId);

        protected internal override string GetPageSubtitle()
        {
            if (IsPerson())
            {
                return $"{GetPersonName(FixedValue)}";
            }
            else
            {
                return "Määramata alalehe pealkiri";
            }
        }
    }
}