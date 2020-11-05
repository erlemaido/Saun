using Data.Units;
using Domain.Abstractions;

namespace Domain.Units
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