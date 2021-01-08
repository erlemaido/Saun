using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Shop.Cities;
using Data.Shop.Countries;
using Data.Shop.DeliveryTypes;
using Data.Shop.Orders;
using Data.Shop.People;
using Data.Shop.Users;
using Domain.Shop.Cities;
using Domain.Shop.Countries;
using Domain.Shop.DeliveryTypes;
using Domain.Shop.Orders;
using Domain.Shop.People;
using Domain.Shop.Users;
using Facade.Shop.Orders;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Orders
{
    public sealed class OrdersPage : ViewPage<IOrdersRepository, Order, OrderView, OrderData>
    {
        public OrdersPage(
            IOrdersRepository repository,
            IPeopleRepository peopleRepository,
            IUsersRepository usersRepository, 
            IDeliveryTypesRepository deliveryTypesRepository,
            ICountriesRepository countriesRepository, 
            ICitiesRepository citiesRepository) : base(repository, PagesNames.Orders)
        {
            People = NewPeopleList<Person, PersonData>(peopleRepository);
            Users = NewUsersList<User, UserData>(usersRepository);
            DeliveryTypes = NewItemsList<DeliveryType, DeliveryTypeData>(deliveryTypesRepository);
            Countries = NewItemsList<Country, CountryData>(countriesRepository);
            Cities = NewItemsList<City, CityData>(citiesRepository);
        }

        public IEnumerable<SelectListItem> People { get; set; }
        public IEnumerable<SelectListItem> Users { get; set; }
        public IEnumerable<SelectListItem> DeliveryTypes { get; set; }
        public IEnumerable<SelectListItem> Countries { get; set; }
        public IEnumerable<SelectListItem> Cities { get; set; }

        protected internal override Order ToObject(OrderView view) => OrderViewFactory.Create(view);
        
        protected internal override OrderView ToView(Order obj) => OrderViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Orders, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new OrderView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public string GetPersonName(string itemPersonId) => GetItemName(People, itemPersonId);

        public string GetUserName(string itemUserId) => GetItemName(Users, itemUserId);

        public string GetDeliveryTypeName(string itemDeliveryTypeId) => GetItemName(DeliveryTypes, itemDeliveryTypeId);

        public string GetCountryName(string itemCountryId) => GetItemName(Countries, itemCountryId);

        public string GetCityName(string itemCityId) => GetItemName(Cities, itemCityId);
        
        private bool IsPerson() => FixedFilter == GetMember.Name<OrderView>(x => x.PersonId);
        
        private bool IsUser() => FixedFilter == GetMember.Name<OrderView>(x => x.UserId);
        private bool IsDeliveryType() => FixedFilter == GetMember.Name<OrderView>(x => x.DeliveryTypeId);
        
        private bool IsCountry() => FixedFilter == GetMember.Name<OrderView>(x => x.CountryId);
        private bool IsCity() => FixedFilter == GetMember.Name<OrderView>(x => x.CityId);
        
        protected internal override string GetPageSubtitle()
        {
            if (IsPerson())
            {
                return $"{GetPersonName(FixedValue)}";
            }
            else if (IsUser())
            {
                return $"{GetUserName(FixedValue)}";
            }
            else if (IsDeliveryType())
            {
                return $"{GetDeliveryTypeName(FixedValue)}";
            }
            else if (IsCountry())
            {
                return $"{GetCountryName(FixedValue)}";
            }
            else if (IsCity())
            {
                return $"{GetCityName(FixedValue)}";
            }
            else
            {
                return "Määramata alalehe pealkiri";
            }
        }
    }
    
}
