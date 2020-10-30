using Data.Units;
using Domain.Units;
using Infra.Abstractions;

namespace Infra.Units
{
    public sealed class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {
        
    }
}