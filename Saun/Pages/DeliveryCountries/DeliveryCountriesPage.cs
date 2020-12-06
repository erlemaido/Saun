using System;
using System.Collections.Generic;
using System.Text;
using Data.DeliveryCountry;
using Domain.DeliveryCountries;
using Domain.ProductTypes;
using Facade.DeliveryCountries;
using Facade.ProductTypes;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.DeliveryCountries
{
    public sealed class DeliveryCountriesPage : ViewsPage<IDeliveryCountriesRepository, DeliveryCountry, DeliveryCountryView, DeliveryCountryData>
    {
        public DeliveryCountriesPage(IDeliveryCountriesRepository deliveryCountriesRepository) : base(deliveryCountriesRepository, PagesNames.DeliveryCountries)
        {
        }
        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.DeliveryCountries, UriKind.Relative);

        protected internal override DeliveryCountry ToObject(DeliveryCountryView view) => DeliveryCountryViewFactory.Create(view);

        protected internal override DeliveryCountryView ToView(DeliveryCountry obj) => DeliveryCountryViewFactory.Create(obj);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new DeliveryCountryView() { Id = Guid.NewGuid().ToString() };

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
    
}
