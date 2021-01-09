using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;

namespace Tests.Pages.Consts {

    [TestClass] public class CaptionsTests : BaseTests {

        [TestInitialize] public void TestInitialize() => type = typeof(Captions);

        [TestMethod] public void BackToListTest() =>
            Assert.AreEqual("Tagasi", Captions.BackToList);

        [TestMethod] public void CreateTest() =>
            Assert.AreEqual("Lisa uus", Captions.Create);

        [TestMethod] public void DeleteTest() =>
            Assert.AreEqual("Kustuta", Captions.Delete);

        [TestMethod] public void DetailsTest() =>
            Assert.AreEqual("Vaata lähemalt", Captions.Details);

        [TestMethod] public void EditTest() =>
            Assert.AreEqual("Muuda", Captions.Edit);

        [TestMethod] public void SelectTest() =>
            Assert.AreEqual("Vali", Captions.Select);
        [TestMethod]
        public void FirstTest() =>
            Assert.AreEqual("Esimene", Captions.First);
        [TestMethod]
        public void LastTest() =>
            Assert.AreEqual("Viimane", Captions.Last);
        [TestMethod]
        public void NextTest() =>
            Assert.AreEqual("Järgmine", Captions.Next);
        [TestMethod]
        public void PreviousTest() =>
            Assert.AreEqual("Eelmine", Captions.Previous);
        [TestMethod]
        public void AddToBasketTest() =>
            Assert.AreEqual("Lisa Ostukorvi", Captions.AddToBasket);

    }

}

