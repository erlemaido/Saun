using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Baskets;
using Data.Shop.People;
using Data.Shop.Products;
using Domain.Shop.Baskets;
using Domain.Shop.People;
using Domain.Shop.Products;
using Facade.Shop.Baskets;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Baskets;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Baskets
{
    [TestClass]
    public class BasketsPageTests : SealedViewPageTests<BasketsPage, IBasketsRepository, Basket, BasketView, BasketData>
    {
        private TestRepository _repository;
        private ProductsTestRepository _productsTest;
        private PeopleTestRepository _peopleTest;
        private BasketData _data;
        private PersonData _peopleData;
        private string _selectedId;
        protected override string GetId(BasketView item) => item.Id;

        protected override string PageTitle() => PagesNames.Baskets;

        protected override string PageUrl() => PagesUrls.BasketItems;
        protected override Basket CreateObj(BasketData d) => new Basket(d);
        private bool IsPerson() => obj.FixedFilter == GetMember.Name<BasketView>(x => x.PersonId);


        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _selectedId = GetRandom.String();
            _repository = new TestRepository();
            _productsTest = new ProductsTestRepository();
            _peopleTest = new PeopleTestRepository();
            _data = GetRandom.Object<BasketData>();
            _peopleData = GetRandom.Object<PersonData>();
            AddRandomPeople();
            AddRandomBaskets();
            obj = new BasketsPage(_repository, _productsTest, _peopleTest);
        }

        private void AddRandomBaskets()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<BasketData>();
                _repository.Add(new Basket(d)).GetAwaiter();
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

        private class TestRepository
            : UniqueRepository<Basket, BasketData>,
                IBasketsRepository
        {
            protected override string GetId(BasketData d) => d.Id;

            public Task AddAll(List<Basket> obj)
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

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<BasketView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<BasketData>();
            var view = obj.ToView(CreateObj(d));
            TestArePropertyValuesEqual(view, d);
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
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Ostukorv", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Baskets", obj.PageUrl.ToString());

        [TestMethod]
        public void GetPageSubtitleTest()
        {
            var list = _peopleTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<BasketView>(x => x.PersonId);
            if (!IsPerson()) return;
            foreach (var person in list.Where(person => person.Id == _peopleData.Id))
            {
                obj.FixedValue = person.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }
        }
        
        [TestMethod]
        public void OnGetIndexAsyncTest()
        {
            var list = _peopleTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.People.Count());
        }
        
        [TestMethod]
        public void OnPostRemoveFromCartAsyncTest()
        {
        }
        
        [TestMethod]
        public void OnPostCreateBasketAsyncTest()
        {
        }
        
        [TestMethod]
        public void GetItemPriceTest()
        {
        }
        
        [TestMethod]
        public void RemoveFromCartTest()
        {
        }
        
        [TestMethod]
        public void GetPriceSumTest()
        {
        }
        
        [TestMethod]
        public void GetPictureUrlTest()
        {
        }
        
        [TestMethod]
        public void CartTest()
        {
        }
        
        [TestMethod]
        public void ProductsTest()
        {
        }
        
        [TestMethod]
        public void GetProductNameTest()
        {
            var name = obj.GetPersonName(_peopleData.Id);
            Assert.AreEqual(_peopleData.FirstName + " " + _peopleData.LastName, name);
        }
        
        [TestMethod]
        public void GetProductPictureUrlTest()
        {
            var name = obj.GetPersonName(_peopleData.Id);
            Assert.AreEqual(_peopleData.FirstName + " " + _peopleData.LastName, name);
        }
        
        [TestMethod]
        public void GetProductPriceTest()
        {
            var name = obj.GetPersonName(_peopleData.Id);
            Assert.AreEqual(_peopleData.FirstName + " " + _peopleData.LastName, name);
        }
    }
}