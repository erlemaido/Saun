using System;
using System.Collections.Generic;
using Aids.Reflection;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions {

    [TestClass] public class RowHtmlTests : BaseTests {

        private string _s;

        [TestInitialize] public virtual void TestInitialize() {
            type = typeof(RowHtml);
            _s = GetRandom.String();
        }

        [TestMethod] public void RowTest() {

            var obj = new HtmlHelperMock<UnitView>().Row(
                GetRandom.Bool(),
                new Uri(GetRandom.String(), UriKind.Relative),

                GetRandom.String(),
                new HtmlContentMock(GetRandom.String()),
                new HtmlContentMock(GetRandom.String()));

            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void FilteredRowTest() {

            var obj = new HtmlHelperMock<UnitView>().Row(
                GetRandom.Bool(),
                new Uri(GetRandom.String(), UriKind.Relative),
                GetRandom.String(),
                GetRandom.String(),
                GetRandom.String(),
                new HtmlContentMock(GetRandom.String()),
                new HtmlContentMock(GetRandom.String()));

            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void SearchedRowTest() {
            var obj = new HtmlHelperMock<UnitView>().Row(
                GetRandom.Bool(),
                new Uri(GetRandom.String(), UriKind.Relative),
                GetRandom.String(),
                GetRandom.String(), GetRandom.String(),
                GetRandom.UInt8(),
                GetRandom.String(), GetRandom.String(),
                new HtmlContentMock(GetRandom.String()),
                new HtmlContentMock(GetRandom.String()));
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void InternalRowTest() {
            var a = GetRandom.Object<Args>();
            var obj = RowHtml.Row(
                GetRandom.Bool(),
                a,
                new HtmlContentMock(GetRandom.String()),
                new HtmlContentMock(GetRandom.String()));
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void StringsTest() {
            var expected = new List<string> {
                "<td>",
                _s,
                "</td>",
                "<td>",
                "Edit",
                "|",
                "Details",
                "|",
                "Delete",
                "</td>"
            };
            var a = GetRandom.Object<Args>();
            var actual = RowHtml.HtmlStrings(
                false,
                a,
                new HtmlContentMock(_s));
            // TestHtml.Strings(actual, expected);
        }

        [TestMethod] public void SelectStringsTest() {
            var expected = new List<string> {
                "<td>",
                _s,
                "</td>",
                "<td>",
                "Vali",
                "|",
                "Edit",
                "|",
                "Details",
                "|",
                "Delete",
                "</td>"
            };
            var a = GetRandom.Object<Args>();
            var actual = RowHtml.HtmlStrings(
                true,
                a,
                new HtmlContentMock(_s));
            // TestHtml.Strings(actual, expected);
        }

        [TestMethod] public void AddValueTest() {
            var value = new HtmlContentMock(_s);
            var l = new List<object>();
            RowHtml.AddValue(l, value);
            Assert.AreEqual(3, l.Count);
            Assert.AreEqual("<td>", l[0].ToString());
            Assert.AreEqual(_s, l[1].ToString());
            Assert.AreEqual("</td>", l[2].ToString());
        }

    }

}