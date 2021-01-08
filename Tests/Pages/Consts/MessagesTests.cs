using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;

namespace Tests.Pages.Consts {

    [TestClass] public class MessagesTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Messages);

        [TestMethod]
        public void PagesOfTest() =>
            Assert.AreEqual("Page {0} of {1}", Messages.PagesOf);

    }

}
