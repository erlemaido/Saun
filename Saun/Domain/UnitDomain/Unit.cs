using Saun.Data.Unit;
using Saun.Domain.Abstractions;

namespace Saun.Domain.UnitDomain
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