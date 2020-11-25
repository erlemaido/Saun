using System;
using Data.Units;
using Domain.Units;
using Facade.Units;

namespace Pages.Units
{
    public class UnitsPage : ViewPage<IUnitsRepository, Unit, UnitView, UnitData>
    {
        public UnitsPage(IUnitsRepository repository) : base(repository, "Ühikud?")
        {
        }

        protected internal override Unit ToObject(UnitView view) => UnitViewFactory.Create(view);

        protected internal override UnitView ToView(Unit obj) => UnitViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri("/Units", UriKind.Relative);
    }
}
