using Data.Shop.BasketItems;
using Domain.Shop.BasketItems;
using Infra.Abstractions;

namespace Infra.Shop.BasketItems
{
    public sealed class BasketItemsRepository : UniqueEntityRepository<BasketItem, BasketItemData>, IBasketItemsRepository
    {
        protected internal override BasketItem ToDomainObject(BasketItemData data) => new BasketItem(data);

        public BasketItemsRepository(SaunaDbContext context) : base(context, context.BasketItems)
        {
        }
    }
}