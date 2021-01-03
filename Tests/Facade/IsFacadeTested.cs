using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Facade
{
    [TestClass]
    public class IsFacadeTested : AssemblyTests
    {
        private const string Assembly = "Facade";

        protected override string Namespace(string name) { return $"{Assembly}.{name}"; }

        [TestMethod] public void IsAbstractionsTested() { IsAllTested(Assembly, Namespace("Abstractions")); }
        [TestMethod] public void IsShopTested() { IsAllTested(Assembly, Namespace("Shop")); }
    }
}
