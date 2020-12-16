using System;
using System.Collections.Generic;
using System.Text;
using Data.Shop.DeliveryTypes;
using Domain.Shop.DeliveryTypes;
using Facade.Shop.DeliveryTypes;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.DeliveryTypes
{
    public sealed class DeliveryTypesPage : ViewsPage<IDeliveryTypesRepository, DeliveryType, DeliveryTypeView, DeliveryTypeData>
    {
        public DeliveryTypesPage(IDeliveryTypesRepository deliveryTypesRepository) : base(deliveryTypesRepository, PagesNames.DeliveryTypes)
        {
        }
        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.DeliveryTypes, UriKind.Relative);

        protected internal override DeliveryType ToObject(DeliveryTypeView view) => DeliveryTypeViewFactory.Create(view);

        protected internal override DeliveryTypeView ToView(DeliveryType obj) => DeliveryTypeViewFactory.Create(obj);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new DeliveryTypeView() { Id = Guid.NewGuid().ToString() };

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
    
}
