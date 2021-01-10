using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Aids.Helpers;
using Data.Shop.BasketItems;
using Data.Shop.Baskets;
using Data.Shop.People;
using Domain.Shop.BasketItems;
using Domain.Shop.Baskets;
using Domain.Shop.People;
using Domain.Shop.Products;
using Facade.Shop.Baskets;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Baskets
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public sealed class BasketsPage : ViewPage<IBasketsRepository, Basket, BasketView, BasketData>
    {
        public BasketsPage(
            IBasketsRepository repository,
            IProductsRepository productsRepository,
            IPeopleRepository peopleRepository) : base(repository, PagesNames.Baskets)
        {
            Products = productsRepository.Get().Result;
            People = NewPeopleList<Person, PersonData>(peopleRepository);
        }

        public IEnumerable<SelectListItem> People { get; set; }
        public List<Product> Products { get; set; }
        public List<BasketItem> Cart { get; set; }
        protected internal override Basket ToObject(BasketView view) => BasketViewFactory.Create(view);

        protected internal override BasketView ToView(Basket obj) => BasketViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Baskets, UriKind.Relative);

        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new BasketView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }

        public override async Task OnGetIndexAsync(string sortOrder,
            string id, string currentFilter, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue)
        {
            Cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart") ?? new List<BasketItem>();
            SelectedId = id;
            await GetList(sortOrder, currentFilter, searchString, pageIndex,
                fixedFilter, fixedValue).ConfigureAwait(true);
        }

        public string GetProductName(string id) => GetItemName(id);
        
        public string GetProductPictureUrl(string id) => GetPictureUrl(id);

        public string GetPersonName(string itemPersonId) => GetItemName(People, itemPersonId);

        public async Task<IActionResult> OnPostRemoveFromCartAsync(string itemId)
        {
            RemoveFromCart(itemId);
            Cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart") ?? new List<BasketItem>();

            return Page();
        }

        public async Task<IActionResult> OnPostCreateBasketAsync(string itemId)
        {
            Cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart") ?? new List<BasketItem>();

            var contains = Cart.Any(item => item.Data.ProductId == itemId);
            if (!contains)
            {
                Cart.Add(new BasketItem(new BasketItemData()
                {
                    Id = Guid.NewGuid().ToString(),
                    ProductId = itemId,
                    Quantity = 1
                }));
            }
            else
            {
                var product = Cart.FirstOrDefault(item => item.Data.ProductId == itemId);
                Debug.Assert(product != null, nameof(product) + " != null");
                product.Data.Quantity++;
            }

            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);

            return Redirect(new Uri(PagesUrls.Products, UriKind.Relative).ToString() + "?handler=index");
        }

        public double? GetItemPrice(string id)
        {
            return Products.Find(i => i.Id == id)?.Data.Price;
        }
        
        public string GetPictureUrl(string id)
        {
            return Products.Find(i => i.Id == id)?.Data.PictureUrl;
        }

        private string GetItemName(string id)
        {
            return Products.FirstOrDefault(item => item.Id == id)?.Data.Name;
        }

        public double? GetPriceSum()
        {
            Cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart") ?? new List<BasketItem>();

            return Cart.Sum(item => item.Data.Quantity * GetItemPrice(item.Data.ProductId));
        }

        public void RemoveFromCart(string id)
        {
            Cart = HttpContext.Session.GetObjectFromJson<List<BasketItem>>("cart") ?? new List<BasketItem>();
            var item = Cart.FirstOrDefault(i => i.Data.ProductId == id);
            if (item != null)
            {
                if (item.Data.Quantity == 1)
                {
                    Cart.Remove(item);
                }
                else
                {
                    item.Data.Quantity--;
                }
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", Cart);
        }
    }
}