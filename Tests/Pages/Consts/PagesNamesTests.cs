using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;

namespace Tests.Pages.Consts
{
    [TestClass]
    public class PagesNamesTests : BaseTests
    {
        [TestInitialize] public void TestInitialize() => type = typeof(PagesNames);
        [TestMethod] public void BasketItemsTest() => Assert.AreEqual("Ostukorvi read", PagesNames.BasketItems);
        [TestMethod] public void BasketsTest() => Assert.AreEqual("Ostukorvid", PagesNames.Baskets);
        [TestMethod] public void BrandsTest() => Assert.AreEqual("Brändid", PagesNames.Brands);
        [TestMethod] public void CountriesTest() => Assert.AreEqual("Riigid", PagesNames.Countries);
        [TestMethod] public void CitiesTest() => Assert.AreEqual("Linnad", PagesNames.Cities);
        [TestMethod] public void DeliveryTypesTest() => Assert.AreEqual("Tarne tüübid", PagesNames.DeliveryTypes);
        [TestMethod] public void OrderItemsTest() => Assert.AreEqual("Tellimuse read", PagesNames.OrderItems);
        [TestMethod] public void OrdersTest() => Assert.AreEqual("Tellimused", PagesNames.Orders);
        [TestMethod] public void OrderStatusesTest() => Assert.AreEqual("Tellimuse staatused", PagesNames.OrderStatuses);
        [TestMethod] public void PaymentsTest() => Assert.AreEqual("Maksed", PagesNames.Payments);
        [TestMethod] public void PaymentTypesTest() => Assert.AreEqual("Maksevahendid", PagesNames.PaymentTypes);
        [TestMethod] public void PeopleTest() => Assert.AreEqual("Isikud", PagesNames.People);
        [TestMethod] public void ProductsTest() => Assert.AreEqual("Tooted", PagesNames.Products);
        [TestMethod] public void ProductTypesTest() => Assert.AreEqual("Toote tüübid", PagesNames.ProductTypes);
        [TestMethod] public void ReviewsTest() => Assert.AreEqual("Arvustused", PagesNames.Reviews);
        [TestMethod] public void RolesTest() => Assert.AreEqual("Rollid", PagesNames.Roles);
        [TestMethod] public void StatusesTest() => Assert.AreEqual("Tellimuse staatused", PagesNames.Statuses);
        [TestMethod] public void StockTest() => Assert.AreEqual("Laoseis", PagesNames.Stock);
        [TestMethod] public void UnitsTest() => Assert.AreEqual("Ühikud", PagesNames.Units);
        [TestMethod] public void UserRolesTest() => Assert.AreEqual("Kasutaja rollid", PagesNames.UserRoles);
        [TestMethod] public void UsersTest() => Assert.AreEqual("Kasutajad", PagesNames.Users);


    }
}
