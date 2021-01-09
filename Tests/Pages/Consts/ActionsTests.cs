using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sauna.Pages.Abstractions.Constants;

namespace Tests.Pages.Consts
{
    [TestClass]
    public class ActionsTests : BaseTests
    {

        [TestInitialize] public virtual void TestInitialize() => type = typeof(Actions);
        [TestMethod] public void EditTest() => Assert.AreEqual("Edit", Actions.Edit);
        [TestMethod] public void DetailsTest() => Assert.AreEqual("Details", Actions.Details);
        [TestMethod] public void DeleteTest() => Assert.AreEqual("Delete", Actions.Delete);
        [TestMethod] public void IndexTest() => Assert.AreEqual("Index", Actions.Index);
        [TestMethod] public void AddToBasketTest() => Assert.AreEqual("AddToCart", Actions.AddToBasket);


    }
}
