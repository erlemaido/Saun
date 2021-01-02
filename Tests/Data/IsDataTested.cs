using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Data
{
    [TestClass]
    public class IsDataTested : AssemblyTests
    {
        private const string Assembly = "Data";

        protected override string Namespace(string name) { return $"{Assembly}.{name}"; }

        [TestMethod] public void IsAbstractionsTested() { IsAllTested(Assembly, Namespace("Abstractions")); }
        [TestMethod] public void IsShopTested() { IsAllTested(Assembly, Namespace("Shop")); }
    }
}
