using Data.Shop.Units;
using Domain.Abstractions;

namespace Domain.Shop.Units
{
    public sealed class Unit : NamedEntity<UnitData>
    {
        public Unit() : this(null)
        {
            
        }

        public Unit(UnitData data) : base(data)
        {
            
        }
    }
}