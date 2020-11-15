using System;
using System.Collections.Generic;
using System.Text;
using Data.Units;
using Domain.Units;
using Facade.Units;

namespace Pages.Units
{
    class UnitsPage : CommonPage<IUnitsRepository, Unit, UnitView, UnitData>
    {
        protected internal UnitsPage(IUnitsRepository UnitsRepository) : base(
            UnitsRepository)
        {
            PageTitle = "??";
        }

        public override Guid ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/Saun/Units";

        protected internal override Unit ToObject(UnitView view)
        {
            return UnitViewFactory.Create(view);
        }

        protected internal override UnitView ToView(Unit obj)
        {
            return UnitViewFactory.Create(obj);
        }
    }
}
