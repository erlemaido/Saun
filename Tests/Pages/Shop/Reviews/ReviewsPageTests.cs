using Aids.Reflection;
using Data.Shop.Products;
using Data.Shop.Reviews;
using Data.Shop.Users;
using Domain.Shop.Products;
using Domain.Shop.Reviews;
using Domain.Shop.Users;
using Facade.Shop.Reviews;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Shop.Reviews;
using Tests.Pages.Abstractions;

namespace Tests.Pages.Shop.Reviews
{
    [TestClass]
    public class ReviewsPageTests : SealedViewPageTests<ReviewsPage,
            IReviewsRepository, Review, ReviewView, ReviewData>
    {
        internal class reviewsRepository : UniqueRepository<Review, ReviewData>, IReviewsRepository
        {
            protected override string GetId(ReviewData d) => d.Id;

        }
        private class productsRepository : UniqueRepository<Product, ProductData>, IProductsRepository
        {
            protected override string GetId(ProductData d) => d.Id;
        }

        private class usersRepository : UniqueRepository<User, UserData>, IUsersRepository
        {
            protected override string GetId(UserData d) => d.Id;
        }

        private reviewsRepository Reviews;
        private productsRepository Products;
        private usersRepository Users;

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            Reviews = new reviewsRepository();
            Products = new productsRepository();
            Users = new usersRepository();
            obj = new ReviewsPage(Reviews,Products,Users);
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
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetProductNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void ProductsTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void GetUserNameTest()
        {
            Assert.IsNull(null);
        }

        [TestMethod]
        public void UsersTest()
        {
            Assert.IsNull(null);
        }


        protected override Review CreateObj(ReviewData d)
        {
            throw new System.NotImplementedException();
        }

        protected override string GetId(ReviewView item)
        {
            throw new System.NotImplementedException();
        }

        protected override string PageTitle()
        {
            throw new System.NotImplementedException();
        }

        protected override string PageUrl()
        {
            throw new System.NotImplementedException();
        }

    }

}