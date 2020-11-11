using System.Threading.Tasks;
using Data.Brands;
using Domain.Brands;
using Infra.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace Infra.CatalogItemBrands
{
    public sealed class BrandsRepository : UniqueEntityRepository<Brand, BrandData>, IBrandsRepository
    {
        protected internal override Brand ToDomainObject(BrandData uniqueEntityData) => new Brand(uniqueEntityData);

        public BrandsRepository(SaunDbContext c) : base(c, c.CatalogItemBrands)
        {
        }
    }
}