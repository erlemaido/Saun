using Aids.Methods;
using Data.Units;
using Domain.Units;

namespace Facade.Units
{
    public static class UnitViewFactory
    {
        public static Unit Create(UnitView view)
        {
            var unitData = new UnitData();
            Copy.Members(view, unitData);
            
            return new Unit(unitData);
        }
        public static UnitView Create(Unit unit)
        {
            var view = new UnitView();
            Copy.Members(unit.Data, view);

            return view;
        }
    }
}
