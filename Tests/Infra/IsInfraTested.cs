using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.Infra
{
    [TestClass]
    public class IsInfraTested : AssemblyTests
    {
        private const string Assembly = "Infra";

        protected override string Namespace(string name)
        {
            return $"{Assembly}.{name}";
        }
        [TestMethod] public void IsAbstractionsTested() { IsAllTested(Assembly, Namespace("Abstractions")); }
        [TestMethod]
        public void IsShopTested()
        {
            IsAllTested(Assembly, Namespace("Shop"));
        }

        //[TestMethod]
        //public void IsTested()
        //{
        //    IsAllTested(base.Namespace("Infra"));
        //}
    }
}
