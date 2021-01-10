using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Orders;
using Domain.Shop.Orders;
using Infra;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra.Abstractions
{
    [TestClass]
    public class SortedRepositoryTests : AbstractClassTests<SortedRepository<Order, OrderData>, BaseRepository<Order, OrderData>>
    {
        private static string TestingClass => nameof(OrderData);
        private class TestClass : SortedRepository<Order, OrderData>
        {
            public TestClass(DbContext c, DbSet<OrderData> s) : base(c, s)
            {

            }

            protected internal override Order ToDomainObject(OrderData d) => new Order(d);
            protected override OrderData GetDataById(OrderData d) => dbSet.Find(d.Id);


            protected override async Task<OrderData> GetData(string id)
            {
                await Task.CompletedTask;
                return new OrderData();
            }

            protected override string GetId(Order entity) => entity?.Data?.Id;
        }

        [TestInitialize]
        public override void TestInitialize()
        {
            base.TestInitialize();
            var options = new DbContextOptionsBuilder<SaunaDbContext>().UseInMemoryDatabase("TestDb").Options;
            var c = new SaunaDbContext(options);
            obj = new TestClass(c, c.Orders);
        }

        [TestMethod]
        public void SortOrderTest()
        {
            IsNullableProperty(() => obj.SortOrder, x => obj.SortOrder = x);
        }

        [TestMethod]
        public void DescendingStringTest()
        {
            var propertyName = GetMember.Name<TestClass>(x => x.DescendingString);
            IsReadOnlyProperty(obj, propertyName, "_desc");
        }

        [TestMethod]
        public void SetSortingTest()
        {
            // void Test(IQueryable<OrderData> d, string sortOrder)
            // {
            //     obj.SortOrder = sortOrder + obj.DescendingString;
            //     var set = obj.AddSorting(d);
            //     Assert.IsNotNull(set);
            //     Assert.AreNotEqual(d, set);
            //     var str = set.Expression.ToString();
            //     Assert.IsTrue(str
            //         .Contains($"{TestingClass}]).OrderByDescending(x => Convert(x.{sortOrder}, Object)"));
            //     obj.SortOrder = sortOrder;
            //     set = obj.AddSorting(d);
            //     Assert.IsNotNull(set);
            //     Assert.AreNotEqual(d, set);
            //     str = set.Expression.ToString();
            //     Assert.IsTrue(str.
            //         Contains($"Data.Shop.Orders.OrderData]).OrderBy(x => Convert(x.{sortOrder}, Object)"));
            // }

            Assert.IsNull(obj.AddSorting(null));
            IQueryable<OrderData> data = obj.dbSet;
            obj.SortOrder = null;
            Assert.AreEqual(data, obj.AddSorting(data));
            //Test(data, GetMember.Name<OrderData>(x => x.Id));
            //Test(data, GetMember.Name<OrderData>(x => x.Name));
            //Test(data, GetMember.Name<OrderData>(x => x.CityId));
            //Test(data, GetMember.Name<OrderData>(x => x.CountryId));
            //Test(data, GetMember.Name<OrderData>(x => x.Date));
            //Test(data, GetMember.Name<OrderData>(x => x.DeliveryCost));
            //Test(data, GetMember.Name<OrderData>(x => x.DeliveryTypeId));
            //Test(data, GetMember.Name<OrderData>(x => x.TotalPrice));
            //Test(data, GetMember.Name<OrderData>(x => x.Street));
            //Test(data, GetMember.Name<OrderData>(x => x.ZipCode));
            //Test(data, GetMember.Name<OrderData>(x => x.PersonId));
            //Test(data, GetMember.Name<OrderData>(x => x.UserId));
            //Test(data, GetMember.Name<OrderData>(x => x.Comment));

        }

        [TestMethod]
        public void CreateExpressionTest()
        {
            string s;
            TestCreateExpression(GetMember.Name<OrderData>(x => x.Id));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.Name));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.CityId));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.CountryId));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.Date));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.DeliveryCost));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.DeliveryTypeId));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.TotalPrice));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.Street));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.ZipCode));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.PersonId));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.UserId));
            TestCreateExpression(GetMember.Name<OrderData>(x => x.Comment));

            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.Id), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.Name), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.CityId), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.CountryId), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.Date), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.DeliveryCost), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.DeliveryTypeId), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.TotalPrice), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.Street), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.ZipCode), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.PersonId), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.UserId), s + obj.DescendingString);
            TestCreateExpression(s = GetMember.Name<OrderData>(x => x.Comment), s + obj.DescendingString);
            TestNullExpression(GetRandom.String());
            TestNullExpression(string.Empty);
            TestNullExpression(null);
        }

        private void TestNullExpression(string name)
        {
            obj.SortOrder = name;
            var lambda = obj.CreateExpression();
            Assert.IsNull(lambda);
        }

        private void TestCreateExpression(string expected, string name = null)
        {
            name ??= expected;
            obj.SortOrder = name;
            var lambda = obj.CreateExpression();
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<OrderData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(expected));
        }

        [TestMethod]
        public void LambdaExpressionTest()
        {
            var name = GetMember.Name<OrderData>(x => x.Street);
            var property = typeof(OrderData).GetProperty(name);
            var lambda = obj.LambdaExpression(property);
            Assert.IsNotNull(lambda);
            Assert.IsInstanceOfType(lambda, typeof(Expression<Func<OrderData, object>>));
            Assert.IsTrue(lambda.ToString().Contains(name));
        }

        [TestMethod]
        public void FindPropertyTest()
        {
            string s;
            void Test(PropertyInfo expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.FindProperty());
            }

            Test(null, GetRandom.String());
            Test(null, null);
            Test(null, string.Empty);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Name)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Id)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Street)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Comment)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Date)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.DeliveryCost)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.DeliveryTypeId)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.PersonId)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.TotalPrice)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.UserId)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.ZipCode)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.CityId)), s);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.CountryId)), s);


            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Name)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Id)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Street)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Comment)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.Date)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.DeliveryCost)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.DeliveryTypeId)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.PersonId)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.TotalPrice)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.UserId)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.ZipCode)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.CityId)),
                s + obj.DescendingString);
            Test(typeof(OrderData).GetProperty(s = GetMember.Name<OrderData>(x => x.CountryId)),
                s + obj.DescendingString);

        }

        [TestMethod]
        public void GetNameTest()
        {
            string s;
            void Test(string expected, string sortOrder)
            {
                obj.SortOrder = sortOrder;
                Assert.AreEqual(expected, obj.GetName());
            }

            Test(s = GetRandom.String(), s);
            Test(s = GetRandom.String(), s + obj.DescendingString);
            Test(string.Empty, string.Empty);
            Test(string.Empty, null);
        }

        [TestMethod]
        public void SetOrderByTest()
        {
            // void Test(IQueryable<OrderData> d, Expression<Func<OrderData, object>> e, string expected)
            // {
            //     obj.SortOrder = GetRandom.String() + obj.DescendingString;
            //     var set = obj.AddOrderBy(d, e);
            //     Assert.IsNotNull(set);
            //     Assert.AreNotEqual(d, set); 
            //     Assert.IsFalse(set.Expression.ToString()
            //         .Contains($"Data.Shop.Orders.OrderData]).OrderByDescending({expected})"));
            //     obj.SortOrder = GetRandom.String();
            //     set = obj.AddOrderBy(d, e);
            //     Assert.IsNotNull(set);
            //     Assert.AreNotEqual(d, set); 
            //     Assert.IsTrue(set.Expression.ToString()
            //         .Contains($"Data.Shop.Orders.OrderData]).OrderBy({expected})"));
            // }

            Assert.IsNull(obj.AddOrderBy(null, null));
            IQueryable<OrderData> data = obj.dbSet;
            Assert.AreEqual(data, obj.AddOrderBy(data, null));
            //Test(data, x => x.Date, "x => Convert(x.Date, Object");
            //Test(data, x => x.Id, "x => x.Id");
            //Test(data, x => x.Name, "x => x.Name");
            //Test(data, x => x.Street, "x => x.Street");
            //Test(data, x => x.Comment, "x => x.Comment");
            //Test(data, x => x.CityId, "x => x.CityId");
            //Test(data, x => x.CountryId, "x => x.CountryId");
            //Test(data, x => x.PersonId, "x => x.PersonId");
            //Test(data, x => x.TotalPrice, "x => x.TotalPrice");
            //Test(data, x => x.UserId, "x => x.UserId");
            //Test(data, x => x.ZipCode, "x => x.ZipCode");
            //Test(data, x => x.DeliveryCost, "x => x.DeliveryCost");
            //Test(data, x => x.DeliveryTypeId, "x => x.DeliveryTypeId");

        }

        [TestMethod]
        public void IsDescendingTest()
        {
            void Test(string sortOrder, bool expected)
            {
                obj.SortOrder = sortOrder;
                var actual = obj.IsDescending();
                Assert.AreEqual(expected, actual);
            }
            Test(GetRandom.String(), false);
            Test(GetRandom.String() + obj.DescendingString, true);
            Test(string.Empty, false);
            Test(null, false);
        }
    }
}
