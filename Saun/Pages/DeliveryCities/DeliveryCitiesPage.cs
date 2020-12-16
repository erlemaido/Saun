using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Cities;
using Domain.Cities;
using Facade.DeliveryCities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.DeliveryCities
{
    public sealed class DeliveryCitiesPage : ViewPage<IDeliveryCitiesRepository, DeliveryCity, DeliveryCityView, DeliveryCityData>
    {
        public IEnumerable<SelectListItem> DeliveryCountries { get; }

        public DeliveryCitiesPage(
            IDeliveryCitiesRepository repository,
            IDeliveryCountriesRepository deliveryCountriesRepository) : base(repository, PagesNames.DeliveryCities)
        {
            DeliveryCountries = NewItemsList<DeliveryCountry, DeliveryCountryData>(deliveryCountriesRepository);
        }


        public string GetDeliveryCountryName(string id) => GetItemName(DeliveryCountries, id);


        protected internal override DeliveryCity ToObject(DeliveryCityView view) => DeliveryCityViewFactory.Create(view);

        protected internal override DeliveryCityView ToView(DeliveryCity obj) => DeliveryCityViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.DeliveryCities, UriKind.Relative);


        private bool IsDeliveryCountry() => FixedFilter == GetMember.Name<DeliveryCityView>(x => x.DeliveryCountryId);

        protected internal override string GetPageSubtitle()
        {
            if (IsDeliveryCountry())
            {
                return $"{GetDeliveryCountryName(FixedValue)}";
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
            Item = new DeliveryCityView() { Id = Guid.NewGuid().ToString() };

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}

