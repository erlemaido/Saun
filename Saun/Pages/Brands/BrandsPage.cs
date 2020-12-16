using System;
using Data.Shop.Brands;
using Domain.Shop.Brands;
using Facade.Shop.Brands;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Brands
{
    public class BrandsPage : ViewPage<IBrandsRepository, Brand, BrandView, BrandData>
    {
        public BrandsPage(IBrandsRepository repository) : base(repository, PagesNames.Brands)
        {
        }

        protected internal override Brand ToObject(BrandView view) => BrandViewFactory.Create(view);
        
        protected internal override BrandView ToView(Brand obj) => BrandViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Brands, UriKind.Relative);
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new BrandView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}
