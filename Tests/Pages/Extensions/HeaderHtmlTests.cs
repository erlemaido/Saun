using System.Collections.Generic;
using Aids.Extensions;
using Aids.Reflection;
using Facade.Shop.Units;
using Microsoft.AspNetCore.Html;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Aids;
using Sauna.Pages.Abstractions.Extensions;

namespace Tests.Pages.Extensions {

    [TestClass] public class HeaderHtmlTests : BaseTests {

        [TestInitialize] public virtual void TestInitialize() => type = typeof(HeaderHtml);

        [TestMethod] public void HeaderTest() {
            var obj = new HtmlHelperMock<UnitView>().Header(
                GetRandom.String(),
                GetRandom.String(),
                GetRandom.String(),
                GetRandom.String());
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void LinkHeaderTest() {
            var obj = new HtmlHelperMock<UnitView>().Header(
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>(),
                GetRandom.Object<Link>()
            );
            Assert.IsInstanceOfType(obj, typeof(HtmlContentBuilder));
        }

        [TestMethod] public void AddHeaderTest() {
            var l = new List<object>();
            var s = GetRandom.String();
            HeaderHtml.AddHeader(l, s);
            Assert.AreEqual(3, l.Count);
            Assert.AreEqual("<th>", l[0].ToString());
            Assert.AreEqual(s, l[1].ToString());
            Assert.AreEqual("</th>", l[2].ToString());
        }

        [TestMethod] public void AddLinkTest() {
            var l = new List<object>();
            var link = GetRandom.Object<Link>();
            var id = link.PropertyName.ToLowerCase().RemoveSpaces() + "Column";
            HeaderHtml.AddLink(l, link);
            Assert.AreEqual(3, l.Count);
            Assert.AreEqual("<th>", l[0].ToString());
            Assert.AreEqual($"<a id=\"{id}\" href=\"{link.Url}\"><span style=\"font-weight:normal\">{link.DisplayName}</span></a>",
                l[1].ToString());
            Assert.AreEqual("</th>", l[2].ToString());
        }

        [TestMethod] public void NameStringsTest() {
            var s = GetRandom.String();
            var l = HeaderHtml.HtmlStrings(s);
            Assert.AreEqual(6, l.Count);
            Assert.AreEqual("<tr>", l[0].ToString());
            Assert.AreEqual("<th>", l[1].ToString());
            Assert.AreEqual(s, l[2].ToString());
            Assert.AreEqual("</th>", l[3].ToString());
            Assert.AreEqual("<th></th>", l[4].ToString());
            Assert.AreEqual("</tr>", l[5].ToString());
        }

        [TestMethod] public void LinkStringTest() {
            var link = GetRandom.Object<Link>();
            var l = HeaderHtml.HtmlStrings(link);
            var id = link.PropertyName.ToLowerCase().RemoveSpaces() + "Column";
            Assert.AreEqual(6, l.Count);
            Assert.AreEqual("<tr>", l[0].ToString());
            Assert.AreEqual("<th>", l[1].ToString());
            Assert.AreEqual($"<a id=\"{id}\" href=\"{link.Url}\"><span style=\"font-weight:normal\">{link.DisplayName}</span></a>", l[2].ToString());
            Assert.AreEqual("</th>", l[3].ToString());
            Assert.AreEqual("<th></th>", l[4].ToString());
            Assert.AreEqual("</tr>", l[5].ToString());
        }

    }

}