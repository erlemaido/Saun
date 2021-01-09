using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;

namespace Tests.Pages.Consts {

    [TestClass] public class MessagesTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Messages);

        [TestMethod]
        public void PagesOfTest() =>
            Assert.AreEqual("{0}/{1}", Messages.PagesOf);

    }

}
