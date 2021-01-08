using System;
using Data.Shop.PaymentTypes;
using Domain.Shop.PaymentTypes;
using Facade.Shop.PaymentTypes;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.PaymentTypes
{
    public sealed class PaymentTypesPage : ViewPage<IPaymentTypesRepository, PaymentType, PaymentTypeView, PaymentTypeData>
    {
        public PaymentTypesPage(IPaymentTypesRepository repository) : base(repository, PagesNames.PaymentTypes)
        {
        }

        protected internal override PaymentType ToObject(PaymentTypeView view) => PaymentTypeViewFactory.Create(view);
        
        protected internal override PaymentTypeView ToView(PaymentType obj) => PaymentTypeViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.PaymentTypes, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new PaymentTypeView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}