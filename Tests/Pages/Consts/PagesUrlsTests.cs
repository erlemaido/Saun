using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;

namespace Tests.Pages.Consts
{
    [TestClass]
    public class PagesUrlsTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(PagesUrls);
        [TestMethod] public void CountriesTest() => Assert.AreEqual("/Shop/Countries", PagesUrls.Countries);
        [TestMethod] public void BasketsTest() => Assert.AreEqual("/Shop/Baskets", PagesUrls.Baskets);
        [TestMethod] public void BrandsTest() => Assert.AreEqual("/Shop/Brands", PagesUrls.Brands);
        [TestMethod] public void CitiesTest() => Assert.AreEqual("/Shop/Cities", PagesUrls.Cities);
        [TestMethod] public void DeliveryTypesTest() => Assert.AreEqual("/Shop/DeliveryTypes", PagesUrls.DeliveryTypes);
        [TestMethod] public void OrderItemsTest() => Assert.AreEqual("/Shop/OrderItems", PagesUrls.OrderItems);
        [TestMethod] public void OrdersTest() => Assert.AreEqual("/Shop/Orders", PagesUrls.Orders);
        [TestMethod] public void OrderStatusesTest() => Assert.AreEqual("/Shop/OrderStatuses", PagesUrls.OrderStatuses);
        [TestMethod] public void ProductsTest() => Assert.AreEqual("/Shop/Products", PagesUrls.Products);
        [TestMethod] public void PeopleTest() => Assert.AreEqual("/Shop/People", PagesUrls.People);
        [TestMethod] public void ProductTypesTest() => Assert.AreEqual("/Shop/ProductTypes", PagesUrls.ProductTypes);
        [TestMethod] public void ReviewsTest() => Assert.AreEqual("/Shop/Reviews", PagesUrls.Reviews);
        [TestMethod] public void RolesTest() => Assert.AreEqual("/Shop/Roles", PagesUrls.Roles);
        [TestMethod] public void StockTest() => Assert.AreEqual("/Shop/Stock", PagesUrls.Stock);

        [TestMethod] public void StatusesTest() => Assert.AreEqual("/Shop/Statuses", PagesUrls.Statuses);
        [TestMethod] public void PaymentTypesTest() => Assert.AreEqual("/Shop/PaymentTypes", PagesUrls.PaymentTypes);
        [TestMethod] public void PaymentsTest() => Assert.AreEqual("/Shop/Payments", PagesUrls.Payments);
        [TestMethod] public void UnitsTest() => Assert.AreEqual("/Shop/Units", PagesUrls.Units);
        [TestMethod] public void UserRolesTest() => Assert.AreEqual("/Shop/UserRoles", PagesUrls.UserRoles);
        [TestMethod] public void UsersTest() => Assert.AreEqual("/Shop/Users", PagesUrls.Users);


    }

}
