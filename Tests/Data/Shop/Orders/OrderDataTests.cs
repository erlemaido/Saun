using System;
using System.Collections.Generic;
using System.Text;
using Data.Abstractions;
using Data.Shop.Orders;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data.Shop.Orders
{
    [TestClass]
    public class OrderDataTests : SealedClassTests<OrderData, NamedEntityData>
    {
        [TestMethod]
        public void CityIdTest()
        {
            IsNullableProperty(() => obj.CityId, x => obj.CityId= x);
        }

        [TestMethod]
        public void CountryIdTest()
        {
            IsNullableProperty(() => obj.CountryId,x => obj.CountryId = x);
        }

        [TestMethod]
        public void DeliveryTypeIdTest()
        {
            IsNullableProperty(() => obj.DeliveryTypeId, x => obj.DeliveryTypeId = x);
        }

        [TestMethod]
        public void PersonIdTest()
        {
            IsNullableProperty(() => obj.PersonId, x => obj.PersonId = x);
        }

        [TestMethod]
        public void UserIdTest()
        {
            IsNullableProperty(() => obj.UserId, x => obj.UserId = x);
        }
        [TestMethod]
        public void CommentTest()
        {
            IsNullableProperty(() => obj.Comment, x => obj.Comment = x);
        }
        [TestMethod]
        public void StreetTest()
        {
            IsNullableProperty(() => obj.Street, x => obj.Street = x);
        }
        [TestMethod]
        public void ZipCodeTest()
        {
            IsNullableProperty(() => obj.ZipCode, x => obj.ZipCode = x);
        }
        [TestMethod]
        public void TotalPriceTest()
        {
            IsProperty(() => obj.TotalPrice, x => obj.TotalPrice = x);
        }
        [TestMethod]
        public void DateTest()
        {
            IsProperty(() => obj.Date, x => obj.Date = x);
        }
        [TestMethod]
        public void DeliveryCostTest()
        {
            IsProperty(() => obj.DeliveryCost, x => obj.DeliveryCost = x);
        }
    }
    
}
