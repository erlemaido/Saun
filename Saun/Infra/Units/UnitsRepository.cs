using Data.Units;
using Domain.Units;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Units
{
    public sealed class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {
        protected internal override Unit ToDomainObject(UnitData periodData) => new Unit(periodData);

        public UnitsRepository(DbContext c, DbSet<UnitData> s) : base(c, s)
        {
        }
    }
}