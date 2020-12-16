using Data.Shop.Units;
using Domain.Shop.Units;
using Infra.Abstractions;

namespace Infra.Shop.Units
{
    public sealed class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {
        protected internal override Unit ToDomainObject(UnitData data) => new Unit(data);

        public UnitsRepository(SaunaDbContext context) : base(context, context.Units)
        {
        }
    }
}