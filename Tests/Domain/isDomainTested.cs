using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tests;

namespace TrainingApp.Tests.Domain
{
    [TestClass]
    public class IsDomainTested : AssemblyTests
    {
        private const string Assembly = "Domain";

        protected override string Namespace(string name) { return $"{Assembly}.{name}"; }

        [TestMethod] public void IsAbstractionsTested() { IsAllTested(Assembly, Namespace("Abstractions")); }
        [TestMethod] public void IsShopTested() { IsAllTested(Assembly, Namespace("Shop")); }
    }
}
