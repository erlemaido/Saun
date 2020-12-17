using Data.Shop.Baskets;
using Domain.Shop.Baskets;
using Infra.Abstractions;

namespace Infra.Shop.Baskets
{
    public sealed class BasketsRepository : UniqueEntityRepository<Basket, BasketData>, IBasketsRepository
    {
        protected internal override Basket ToDomainObject(BasketData data) => new Basket(data);

        public BasketsRepository(SaunaDbContext context) : base(context, context.Baskets)
        {
        }
    }
}