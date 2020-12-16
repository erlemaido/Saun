using System;
using Data.Shop.Countries;
using Domain.Shop.Countries;
using Facade.Shop.Countries;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Countries
{
    public sealed class CountriesPage : ViewsPage<ICountriesRepository, Country, CountryView, CountryData>
    {
        public CountriesPage(ICountriesRepository countriesRepository) : base(countriesRepository, PagesNames.Countries)
        {
        }
        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Countries, UriKind.Relative);

        protected internal override Country ToObject(CountryView view) => CountryViewFactory.Create(view);

        protected internal override CountryView ToView(Country obj) => CountryViewFactory.Create(obj);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new CountryView() { Id = Guid.NewGuid().ToString() };

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
    
}
