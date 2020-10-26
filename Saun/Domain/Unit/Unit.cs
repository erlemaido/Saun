using Data.Unit;
using Domain.Abstractions;

namespace Domain.Unit
{
    public sealed class Unit : NamedEntity<UnitData>
    {
        public Unit() : this(null!)
        {
            
        }

        public Unit(UnitData data) : base(data)
        {
            
        }
        
    }
}