using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Pages {

    [TestClass] 
    public class IsPagesTested : AssemblyTests {

        private const string Assembly = "Pages";

        protected override string Namespace(string name) {
            return $"{Assembly}.{name}";
        }
        [TestMethod] public void IsAbstractionsTested() { IsAllTested(Assembly, Namespace("Abstractions")); }

        [TestMethod]
        public void IsShopTested()
        {
            IsAllTested(Assembly, Namespace("Shop"));
        }
    }

}
