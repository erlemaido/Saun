using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Cities;
using Data.Shop.Countries;
using Domain.Shop.Cities;
using Domain.Shop.Countries;
using Facade.Shop.Cities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Cities
{
    public sealed class CitiesPage : ViewPage<ICitiesRepository, City, CityView, CityData>
    {
        public IEnumerable<SelectListItem> Countries { get; }

        public CitiesPage(
            ICitiesRepository repository,
            ICountriesRepository countriesRepository) : base(repository, PagesNames.Cities)
        {
            Countries = NewItemsList<Country, CountryData>(countriesRepository);
        }


        public string GetCountryName(string id) => GetItemName(Countries, id);


        protected internal override City ToObject(CityView view) => CityViewFactory.Create(view);

        protected internal override CityView ToView(City obj) => CityViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Cities, UriKind.Relative);


        private bool IsCountry() => FixedFilter == GetMember.Name<CityView>(x => x.CountryId);

        protected internal override string GetPageSubtitle()
        {
            if (IsCountry())
            {
                return $"{GetCountryName(FixedValue)}";
            }
            else
            {
                return "Määramata alalehe pealkiri";
            }
        }

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new CityView() { Id = Guid.NewGuid().ToString() };

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}

