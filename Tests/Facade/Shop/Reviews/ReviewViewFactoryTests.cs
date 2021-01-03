using Aids.Reflection;
using Data.Shop.Reviews;
using Domain.Shop.Reviews;
using Facade.Shop.Reviews;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade.Shop.Reviews
{
    [TestClass]
    public class ReviewViewFactoryTests : BaseTests
    {
        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(ReviewViewFactory);
        }

        [TestMethod]
        public void CreateTest()
        {
        }

        [TestMethod]
        public void CreateObjectTest()
        {
            var view = GetRandom.Object<ReviewView>();
            var data = ReviewViewFactory.Create(view).Data;
            TestArePropertyValuesEqual(view, data);
        }

        [TestMethod]
        public void CreateViewTest()
        {
            var data = GetRandom.Object<ReviewData>();
            var view = ReviewViewFactory.Create(new Review(data));
            TestArePropertyValuesEqual(view, data);
        }
    }
}
