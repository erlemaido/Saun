using System;
using System.Threading.Tasks;
using Data.Units;
using Domain.Units;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.Units
{
    public sealed class UnitsRepository : UniqueEntityRepository<Unit, UnitData>, IUnitsRepository
    {
        protected override Task<UnitData> GetData(Guid id)
        {
            throw new NotImplementedException();
        }

        protected override Guid GetId(Unit entity)
        {
            throw new NotImplementedException();
        }

        protected internal override Unit ToDomainObject(UnitData periodData)
        {
            throw new NotImplementedException();
        }

        public UnitsRepository(DbContext c, DbSet<UnitData> s) : base(c, s)
        {
        }
    }
}