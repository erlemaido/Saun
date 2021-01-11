using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids.Helpers;
using Data.Shop.Cities;
using Data.Shop.Countries;
using Data.Shop.DeliveryTypes;
using Data.Shop.OrderItems;
using Data.Shop.Orders;
using Data.Shop.People;
using Data.Shop.Users;
using Domain.Shop.BasketItems;
using Domain.Shop.Cities;
using Domain.Shop.Countries;
using Domain.Shop.DeliveryTypes;
using Domain.Shop.OrderItems;
using Domain.Shop.Orders;
using Domain.Shop.People;
using Domain.Shop.Products;
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
        private readonly IOrderItemsRepository _orderItemsRepository;

        public OrdersPage(
            IOrderItemsRepository orderItemsRepository,
            IProductsRepository productsRepository,
            IOrdersRepository repository,
            IPeopleRepository peopleRepository,
            IUsersRepository usersRepository,
            IDeliveryTypesRepository deliveryTypesRepository,
            ICountriesRepository countriesRepository,
            ICitiesRepository citiesRepository) : base(repository, PagesNames.Orders)
        {
            _orderItemsRepository = orderItemsRepository;
            Products = productsRepository.Get().Result;
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
        public List<Product> Products { get; set; }
        public List<BasketItem> Cart { get; set; }

        protected internal override Order ToObject(OrderView view) => OrderViewFactory.Create(view);

        protected internal override OrderView ToView(Order obj) => OrderViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Orders, UriKind.Relative);

        public IActionResult OnGetCreateOrder(
            string itemId, string itemQuantity,
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new OrderView() {Id = Guid.NewGuid().ToString()};
            Item.OrderItems = new List<OrderItemData>();
            Item.Date = DateTime.Now;
            if (itemId == null)
            {
                Cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart") ?? new List<BasketItem>();
                foreach (var item in Cart)
                {
                    Item.OrderItems.Add(new OrderItemData
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = item.Data.ProductId,
                        OrderId = Item.Id,
                        Quantity = item.Data.Quantity
                    });
                }
            }
            else
            {
                Item.OrderItems = new List<OrderItemData>
                {
                    new OrderItemData
                    {
                        Id = Guid.NewGuid().ToString(),
                        ProductId = itemId,
                        OrderId = Item.Id,
                        Quantity = int.Parse(itemQuantity)
                    }
                };
            }

            return base.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, switchOfCreate);
        }

        public override async Task<IActionResult> OnPostCreateAsync(
            string sortOrder,
            string searchString,
            int? pageIndex,
            string fixedFilter,
            string fixedValue)
        {
            if (!await AddObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue)
                .ConfigureAwait(true)) return Page();
            
            return Redirect(IndexUrl.ToString());
        }

        public string GetPersonName(string itemPersonId) => GetItemName(People, itemPersonId);

        public string GetUserName(string itemUserId) => GetItemName(Users, itemUserId);

        public string GetDeliveryTypeName(string itemDeliveryTypeId) => GetItemName(DeliveryTypes, itemDeliveryTypeId);

        public string GetCountryName(string itemCountryId) => GetItemName(Countries, itemCountryId);

        public string GetCityName(string itemCityId) => GetItemName(Cities, itemCityId);
        
        public double? GetPriceSum()
        {
            Cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart") ?? new List<BasketItem>();

            return Math.Round(Cart.Sum(item => item.Data.Quantity * GetItemPrice(item.Data.ProductId)).GetValueOrDefault(0));
        }

        public double? GetItemPrice(string id)
        {
            var price = Products.Find(i => i.Id == id)?.Data.Price;
            Item.TotalPrice = price.GetValueOrDefault(0);
            return price;
        }
        
        public double GetDeliveryPrice()
        {
            var random = new Random().Next(30);
            Item.DeliveryCost = random;
            return random;
        }

        public string GetProductName(string id)
        {
            var name = Products.Find(i => i.Id == id)?.Data.Name;
            return name;
        }

        public override async Task<IActionResult> OnGetDetailsAsync(
            string id, string sortOrder, string searchString, 
            int pageIndex, string fixedFilter, string fixedValue)
        {
            await GetObject(id, sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);
            Item.OrderItems = GetOrderItems(id);
            return Page();
        }

        public List<OrderItemData> GetOrderItems(string id)
        {
            var repositoryResult = _orderItemsRepository.Get().Result;
            return repositoryResult.Where(item => item.Data.OrderId == id).Select(item => item.Data).ToList();
        }
    }
}