using Data.CatalogItemBrands;
using Domain.CatalogItemBrands;
using Infra.Abstractions;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItemBrands
{
    public sealed class CatalogItemBrandsRepository : UniqueEntityRepository<CatalogItemBrand, CatalogItemBrandData>, ICatalogItemBrandsRepository
    {
        protected override Task<CatalogItemBrandData> GetData(Guid id)
        {
            throw new NotImplementedException();
        }

        protected override Guid GetId(CatalogItemBrand entity)
        {
            throw new NotImplementedException();
        }

        protected internal override CatalogItemBrand ToDomainObject(CatalogItemBrandData periodData)
        {
            throw new NotImplementedException();
        }

        public CatalogItemBrandsRepository(DbContext c, DbSet<CatalogItemBrandData> s) : base(c, s)
        {
        }
    }
}