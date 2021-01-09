using System.Linq;
using Aids.Reflection;
using Data.Shop.BasketItems;
using Data.Shop.Products;
using Data.Shop.Reviews;
using Data.Shop.Users;
using Domain.Shop.BasketItems;
using Domain.Shop.Products;
using Domain.Shop.Reviews;
using Domain.Shop.Users;
using Facade.Shop.Reviews;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;
using Sauna.Pages.Shop.Reviews;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Reviews
{
    [TestClass]
    public class ReviewsPageTests : SealedViewPageTests<ReviewsPage,
            IReviewsRepository, Review, ReviewView, ReviewData>
    {
        internal class ReviewsTestRepository : UniqueRepository<Review, ReviewData>, IReviewsRepository
        {
            protected override string GetId(ReviewData d) => d.Id;

        }
        private class ProductsTestRepository : UniqueRepository<Product, ProductData>, IProductsRepository
        {
            protected override string GetId(ProductData d) => d.Id;
        }

        private class UsersTestRepository : UniqueRepository<User, UserData>, IUsersRepository
        {
            protected override string GetId(UserData d) => d.Id;
        }

        private ReviewsTestRepository _reviewsTest;
        private ProductsTestRepository _productsTest;
        private UsersTestRepository _usersTest;
        private ReviewData _data;
        private ProductData _productData;
        private UserData _userData;
        private string _selectedId;
        protected override string GetId(ReviewView item) => item.Id;

        protected override string PageTitle() => PagesNames.Reviews;

        protected override string PageUrl() => PagesUrls.Reviews;
        protected override Review CreateObj(ReviewData d) => new Review(d);

        private bool IsProduct() => obj.FixedFilter == GetMember.Name<ReviewView>(x => x.ProductId);

        private bool IsUser() => obj.FixedFilter == GetMember.Name<ReviewView>(x => x.UserId);

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            _reviewsTest = new ReviewsTestRepository();
            _productsTest = new ProductsTestRepository();
            _usersTest = new UsersTestRepository();
            _data = GetRandom.Object<ReviewData>();
            _productData = GetRandom.Object<ProductData>();
            _userData = GetRandom.Object<UserData>();
            AddRandomReviews();
            AddRandomProducts();
            AddRandomUsers();

            obj = new ReviewsPage(_reviewsTest,_productsTest,_usersTest);
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

        private void AddRandomReviews()
        {
            var count = GetRandom.UInt8(5, 10);
            var idx = GetRandom.UInt8(0, count);

            for (var i = 0; i < count; i++)
            {
                var d = i == idx ? _data : GetRandom.Object<ReviewData>();
                _reviewsTest.Add(new Review(d)).GetAwaiter();
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


        [TestMethod]
        public void PageTitleTest() => Assert.AreEqual("Arvustused", obj.PageTitle);

        [TestMethod]
        public void PageUrlTest() => Assert.AreEqual("/Shop/Reviews", obj.PageUrl.ToString());

        [TestMethod]
        public override void ToObjectTest()
        {
            var view = GetRandom.Object<ReviewView>();
            var o = obj.ToObject(view);
            TestArePropertyValuesEqual(view, o.Data);
        }

        [TestMethod]
        public override void ToViewTest()
        {
            var d = GetRandom.Object<ReviewView>();
            var view = obj.ToView(ReviewViewFactory.Create(d));
            TestArePropertyValuesEqual(view, d);
        }

        [TestMethod]
        public void OnGetCreateTest()
        {
            var page = obj.OnGetCreate(sortOrder, searchString, pageIndex, fixedFilter, fixedValue, createSwitch);
            Assert.IsInstanceOfType(page, typeof(PageResult));
            TestPageProperties();
        }

        [TestMethod]
        public void GetProductNameTest()
        {
            var name = obj.GetProductName(_productData.Id);
            Assert.AreEqual(_productData.Name, name);
        }

        [TestMethod]
        public void ProductsTest()
        {
            var list = _productsTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Products.Count());
        }

        [TestMethod]
        public void GetUserNameTest()
        {
            var name = obj.GetUserName(_userData.Id);
            Assert.AreEqual(_userData.PersonId, name);
        }

        [TestMethod]
        public void UsersTest()
        {
            var list = _usersTest.Get().GetAwaiter().GetResult();
            Assert.AreEqual(list.Count, obj.Users.Count());
        }
        [TestMethod]
        public void GetPageProductSubtitleTest()
        {
            var list = _productsTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<ReviewView>(x => x.ProductId);
            if (!IsProduct()) return;
            foreach (var product in list.Where(product => product.Id == _productData.Id))
            {
                obj.FixedValue = product.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }
        [TestMethod]
        public void GetPageUserSubtitleTest()
        {
            var list = _usersTest.Get().GetAwaiter().GetResult();
            obj.FixedFilter = GetMember.Name<ReviewView>(x => x.ProductId);
            if (!IsUser()) return;
            foreach (var user in list.Where(user => user.Id == _userData.Id))
            {
                obj.FixedValue = user.Id;
                Assert.AreEqual(obj.GetPageSubtitle(), obj.PageSubtitle);
            }

        }
    }

}