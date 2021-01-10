using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.Cities;
using Data.Shop.Countries;
using Data.Shop.DeliveryTypes;
using Data.Shop.OrderItems;
using Data.Shop.Orders;
using Data.Shop.People;
using Data.Shop.Products;
using Data.Shop.Users;
using Domain.Abstractions;
using Domain.Shop.BasketItems;
using Domain.Shop.Baskets;
using Domain.Shop.Cities;
using Domain.Shop.Countries;
using Domain.Shop.DeliveryTypes;
using Domain.Shop.OrderItems;
using Domain.Shop.Orders;
using Domain.Shop.People;
using Domain.Shop.Products;
using Domain.Shop.Users;
using Facade.Shop.Orders;
using Infra.Shop.OrderItems;
using Infra.Shop.Products;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Orders;
using Tests.Pages.Abstractions;
using Tests.Pages.Shop.OrderItems;
using Tests.Pages.Shop.People;

namespace Tests.Pages.Shop.Orders
{
    [TestClass]
    public class OrdersPageTests : SealedViewPageTests<OrdersPage, IOrdersRepository, Order,
        OrderView, OrderData>
    {
        private OrderItemsTestRepository _orderItemsTest;
        private ProductsTestRepository _productsTest;
        private OrdersTestRepository _ordersTest;
        private PeoplePageTests.PeopleTestRepository _peopleTest;
        private DeliveryTypesTestRepository _deliveryTypesTest;
        private UsersTestRepository _usersTest;
        private CountriesTestRepository _countriesTest;
        private CitiesTestRepository _citiesTest;
        private OrderItemData _orderItemData;
        private ProductData _productData;
        private OrderData _data;
        private PersonData _peopleData;
        private UserData _userData;
        private DeliveryTypeData _deliveryTypeData;
        private CountryData _countryData;
        private CityData _cityData;
        private string _selectedId;
        protected override string GetId(OrderView item) => item.Id;

        protected override string PageTitle() => PagesNames.BasketItems;

        protected override string PageUrl() => PagesUrls.BasketItems;
        protected override Order CreateObj(OrderData d) => new Order(d);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();

            _selectedId = GetRandom.String();
            _orderItemsTest = new OrderItemsTestRepository();
            _productsTest = new ProductsTestRepository();
            _ordersTest = new OrdersTestRepository();
            _peopleTest = new PeoplePageTests.PeopleTestRepository();
            _usersTest = new UsersTestRepository();
            _deliveryTypesTest = new DeliveryTypesTestRepository();
            _countriesTest = new CountriesTestRepository();
            _citiesTest = new CitiesTestRepository();
            _orderItemData = GetRandom.Object<OrderItemData>();
            _productData = GetRandom.Object<ProductData>();
            _data = GetRandom.Object<OrderData>();
            _peopleData = GetRandom.Object<PersonData>();
            _userData = GetRandom.Object<UserData>();
            _deliveryTypeData = GetRandom.Object<DeliveryTypeData>();
            _countryData = GetRandom.Object<CountryData>();
            _cityData = GetRandom.Object<CityData>();

            AddRandomOrders();
            AddRandomPeople();
            AddRandomUsers();
            AddRandomDeliveryTypes();
            AddRandomCountries();
            AddRandomCities();
            AddRandomOrderItems();
            AddRandomProducts();
            obj = new OrdersPage(_orderItemsTest, _productsTest, _ordersTest, _peopleTest, _usersTest, _deliveryTypesTest, _countriesTest, _citiesTest);

        }

        private void AddRandomCities()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _cityData : GetRandom.Object<CityData>();
                _citiesTest.Add(new City(d)).GetAwaiter();
            }
        }

        private void AddRandomCountries()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _countryData : GetRandom.Object<CountryData>();
                _countriesTest.Add(new Country(d)).GetAwaiter();
            }
        }

        private void AddRandomDeliveryTypes()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _deliveryTypeData : GetRandom.Object<DeliveryTypeData>();
                _deliveryTypesTest.Add(new DeliveryType(d)).GetAwaiter();
            }
        }

        private void AddRandomUsers()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _userData : GetRandom.Object<UserData>();
                _usersTest.Add(new User(d)).GetAwaiter();
            }
        }
        
        private void AddRandomOrderItems()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _orderItemData : GetRandom.Object<OrderItemData>();
                _orderItemsTest.Add(new OrderItem(d)).GetAwaiter();
            }
        }
        
        private void AddRandomProducts()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _productData : GetRandom.Object<ProductData>();
                _productsTest.Add(new Product(d)).GetAwaiter();
            }
        }

        private void AddRandomPeople()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _peopleData : GetRandom.Object<PersonData>();
                _peopleTest.Add(new Person(d)).GetAwaiter();
            }
        }

        private void AddRandomOrders()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<OrderData>();
                _ordersTest.Add(new Order(d)).GetAwaiter();
            }
        }


        private class OrdersTestRepository
            : UniqueRepository<Order, OrderData>,
                IOrdersRepository
        {
            protected override string GetId(OrderData d) => d.Id;

            public Task AddAll(List<Order> obj)
            {
                throw new System.NotImplementedException();
            }
        }
        
        private class OrderItemsTestRepository
            : UniqueRepository<OrderItem, OrderItemData>,
                IOrderItemsRepository
        {
            protected override string GetId(OrderItemData d) => d.Id;
            public Task AddAll(List<OrderItem> obj)
            {
                throw new System.NotImplementedException();
            }
        }
        
        private class ProductsTestRepository
            : UniqueRepository<Product, ProductData>,
                IProductsRepository
        {
            protected override string GetId(ProductData d) => d.Id;
            public Task AddAll(List<Product> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class PeopleTestRepository
            : UniqueRepository<Person, PersonData>,
                IPeopleRepository
        {
            protected override string GetId(PersonData d) => d.Id;
            public Task AddAll(List<Person> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class UsersTestRepository
            : UniqueRepository<User, UserData>,
                IUsersRepository
        {
            protected override string GetId(UserData d) => d.Id;
            public Task AddAll(List<User> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class DeliveryTypesTestRepository
            : UniqueRepository<DeliveryType, DeliveryTypeData>,
                IDeliveryTypesRepository
        {
            protected override string GetId(DeliveryTypeData d) => d.Id;
            public Task AddAll(List<DeliveryType> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class CountriesTestRepository
            : UniqueRepository<Country, CountryData>,
                ICountriesRepository
        {
            protected override string GetId(CountryData d) => d.Id;
            public Task AddAll(List<Country> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        private class CitiesTestRepository
            : UniqueRepository<City, CityData>,
                ICitiesRepository
        {
            protected override string GetId(CityData d) => d.Id;
            public Task AddAll(List<City> obj)
            {
                throw new System.NotImplementedException();
            }
        }

        [TestMethod]
        public override void ToObjectTest()

        {
            var view = GetRandom.Object<OrderView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<OrderData>();
            var view = obj.ToView(CreateObj(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void DeliveryTypesTest()
        {
            var list = _deliveryTypesTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.DeliveryTypes.Count());
        }

        [TestMethod]
        public void UsersTest()
        {
            var list = _usersTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Users.Count());
        }

        [TestMethod]
        public void CountriesTest()
        {
            var list = _countriesTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Countries.Count());
        }

        [TestMethod]
        public void CitiesTest()
        {
            var list = _citiesTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Cities.Count());
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void PeopleTest()
        {
            var list = _peopleTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.People.Count());
        }

        [TestMethod]
        public void GetPersonNameTest()
        {
            var name = obj.GetPersonName(_peopleData.Id);
            Assert.AreEqual(_peopleData.FirstName + " " + _peopleData.LastName, name);
        }

        [TestMethod]
        public void GetUserNameTest()
        {
            var name = obj.GetUserName(_userData.Id);
            Assert.AreEqual(_userData.PersonId, name);
        }

        [TestMethod]
        public void GetDeliveryTypeNameTest()
        {
            var name = obj.GetDeliveryTypeName(_deliveryTypeData.Id);
            Assert.AreEqual(_deliveryTypeData.Name, name);
        }
        
        [TestMethod]
        public void GetPriceSumTest()
        {
        }
        
        [TestMethod]
        public void ProductsTest()
        {
        }
        
        [TestMethod]
        public void CartTest()
        {
        }
        
        [TestMethod]
        public void GetOrderItemsTest()
        {
        }
        
        [TestMethod]
        public void OnGetDetailsAsyncTest()
        {
        }
        
        [TestMethod]
        public void GetItemPriceTest()
        {
        }
        
        [TestMethod]
        public void GetPictureUrlTest()
        {
        }
        
        [TestMethod]
        public void GetDeliveryPriceTest()
        {
        }
        
        [TestMethod]
        public void GetProductNameTest()
        {
        }

        [TestMethod]
        public void GetCountryNameTest()
        {
            var name = obj.GetCountryName(_countryData.Id);
            Assert.AreEqual(_countryData.Name, name);
        }

        [TestMethod]
        public void GetCityNameTest()
        {
            var name = obj.GetCityName(_cityData.Id);
            Assert.AreEqual(_cityData.Name, name);
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Tellimused", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Orders", obj.PageUrl.ToString());
        
        [TestMethod]
        public void OnGetCreateOrderTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }
        
        [TestMethod]
        public void OnPostCreateAsyncTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }
    }

}