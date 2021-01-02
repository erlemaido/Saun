using System;
using System.Collections;
using System.Diagnostics;
using Aids.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    public abstract class BaseClassTests<TClass, TBaseClass> : BaseTests
    {
        protected TClass obj;

        [TestInitialize]
        public virtual void TestInitialize()
        {
            type = typeof(TClass);
        }

        [TestMethod]
        public void IsInheritedTest()
        {
            Assert.AreEqual(typeof(TBaseClass), type.BaseType);
        }

        [TestMethod]
        protected static void IsNullableProperty<T>(Func<T> get, Action<T> set)
        {
            IsProperty<T>(get, set);
            set(default);
            Assert.IsNull(get());
        }

        protected static void IsProperty<T>(Func<T> get, Action<T> set)
        {
            var d = (T) GetRandom.Value(typeof(T));
            Assert.AreNotEqual(d, get());
            set(d);
            Assert.AreEqual(d, get());
        }

        protected void IsReadOnlyProperty(object o, string name, object expected)
        {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.IsFalse(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            var actual = property.GetValue(o);
            Assert.AreEqual(expected, actual);
        }

        protected void IsReadOnlyProperty()
        {
            var n = GetPropertyNameAfter("IsReadOnlyProperty");
            IsReadOnlyProperty(obj, n);
        }

        protected void IsReadOnlyProperty(object expected)
        {
            var n = GetPropertyNameAfter("IsReadOnlyProperty");
            IsReadOnlyProperty(obj, n, expected);
        }

        protected static object IsReadOnlyProperty(object o, string name)
        {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.IsFalse(property.CanWrite);
            Assert.IsTrue(property.CanRead);

            return property.GetValue(o);
        }

        protected string GetPropertyNameAfter(string methodName)
        {
            var stack = new StackTrace();
            int i;
            for (i = 0; i < stack.FrameCount - 1; i++)
            {
                var n = stack.GetFrame(i)?.GetMethod()?.Name;

                if (n == methodName) break;
            }

            for (i += 1; i < stack.FrameCount - 1; i++)
            {
                var n = stack.GetFrame(i)?.GetMethod()?.Name;

                if (n == "MoveNext" || n == "Start") continue;

                return n?.Replace("Test", string.Empty);
            }

            return string.Empty;
        }

        [TestMethod]
        protected static void IsNullableProperty(object o, string name,Type type)
        {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.AreEqual(type,property.PropertyType);
            Assert.IsTrue(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            property.SetValue(o, null);
            var actual = property.GetValue(o);
            Assert.AreEqual(null,actual);
        }

        [TestMethod]
        protected static void IsEnumProperty(object o, string name, Type type)
        {
            var property = o.GetType().GetProperty(name);
            Assert.IsNotNull(property);
            Assert.AreEqual(type, property.PropertyType);
            Assert.IsTrue(property.CanWrite);
            Assert.IsTrue(property.CanRead);
            if (!property.PropertyType.IsEnum) return;
            var random = new Random();
            var values = Enum.GetValues(property.PropertyType);
            var randomValue = ((IList)values)[random.Next(values.Length)];
            property.SetValue(o, randomValue);
            var actual = property.GetValue(o);
            Assert.AreEqual(randomValue, actual);
        }
    }
}
