using Data.CatalogItemBrands;
using Domain.CatalogItemBrands;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItemBrands
{
    public sealed class CatalogItemBrandsRepository : UniqueEntityRepository<CatalogItemBrand, CatalogItemBrandData>, ICatalogItemBrandsRepository
    {
        protected internal override CatalogItemBrand ToDomainObject(CatalogItemBrandData periodData) => new CatalogItemBrand(periodData);

        public CatalogItemBrandsRepository(DbContext c, DbSet<CatalogItemBrandData> s) : base(c, s)
        {
        }
    }
}