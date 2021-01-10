using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Orders;
using Data.Shop.Payments;
using Data.Shop.PaymentTypes;
using Data.Shop.People;
using Domain.Shop.Orders;
using Domain.Shop.Payments;
using Domain.Shop.PaymentTypes;
using Domain.Shop.People;
using Facade.Shop.Payments;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Payments
{
    public sealed class PaymentsPage : ViewPage<IPaymentsRepository, Payment, PaymentView, PaymentData>
    {
        public PaymentsPage(
            IPaymentsRepository repository,
            IOrdersRepository ordersRepository,
            IPaymentTypesRepository paymentTypesRepository,
            IPeopleRepository peopleRepository) : base(repository, PagesNames.Payments)
        {
            Orders = NewItemsList<Order, OrderData>(ordersRepository);
            People = NewPeopleList<Person, PersonData>(peopleRepository);
            PaymentTypes = NewItemsList<PaymentType, PaymentTypeData>(paymentTypesRepository);
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

        public string GetOrderName(string itemOrderId) => GetItemName(Orders, itemOrderId);

        public string GetPersonName(string itemPersonId) => GetItemName(People, itemPersonId);

        public string GetPaymentTypeName(string itemPaymentTypeId) => GetItemName(PaymentTypes, itemPaymentTypeId);
    }
}