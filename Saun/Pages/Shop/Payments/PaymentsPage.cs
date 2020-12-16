using System;
using System.Collections.Generic;
using Data.Shop.Payments;
using Domain.Shop.Payments;
using Facade.Shop.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Payments
{
    public class PaymentsPage : ViewPage<IPaymentsRepository, Payment, PaymentView, PaymentData>
    {
        public PaymentsPage(IPaymentsRepository repository) : base(repository, PagesNames.Payments)
        {
        }

        public IEnumerable<SelectListItem> Orders { get; set; }
        public IEnumerable<SelectListItem> People { get; set; }
        public IEnumerable<SelectListItem> PaymentTypes { get; set; }

        protected internal override Payment ToObject(PaymentView view) => PaymentViewFactory.Create(view);
        
        protected internal override PaymentView ToView(Payment obj) => PaymentViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Payments, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new PaymentView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public string GetOrderName(string itemOrderId)
        {
            throw new NotImplementedException();
        }

        public string GetPersonName(string itemPersonId)
        {
            throw new NotImplementedException();
        }

        public string GetPaymentTypeName(string itemPaymentTypeId)
        {
            throw new NotImplementedException();
        }
    }
}