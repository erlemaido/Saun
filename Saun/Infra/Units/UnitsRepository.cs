using Data.Units;
using Domain.Units;
using Infra.Abstractions;

namespace Infra.Units
{
    public sealed class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {
        protected internal override Unit ToDomainObject(UnitData data) => new Unit(data);

        public UnitsRepository(SaunaDbContext context) : base(context, context.Units)
        {
        }
    }
}