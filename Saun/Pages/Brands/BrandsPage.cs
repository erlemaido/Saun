using System;
using System.Collections.Generic;
using System.Text;
using Data.Brands;
using Domain.Brands;
using Facade.Brands;

namespace Pages.Brands
{
    class BrandsPage : CommonPage<IBrandsRepository, Brand, BrandView, BrandData>
    {
        protected internal BrandsPage(IBrandsRepository BrandsRepository) : base(
            BrandsRepository)
        {
            PageTitle = "Toodete brändid";
        }

        public override Guid ItemId => Item.Id;

        protected internal override string GetPageUrl() => "/Saun/Brands";
       
        protected internal override Brand ToObject(BrandView view)
        {
            return BrandViewFactory.Create(view);
        }

        protected internal override BrandView ToView(Brand obj)
        {
            return BrandViewFactory.Create(obj);
        }
    }
}
