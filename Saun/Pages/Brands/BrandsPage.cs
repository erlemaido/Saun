using System;
using System.Collections.Generic;
using System.Text;
using Data.Brands;
using Domain.Brands;
using Facade.Brands;

namespace Pages.Brands
{
    public class BrandsPage : ViewPage<IBrandsRepository, Brand, BrandView, BrandData>
    {
        public BrandsPage(IBrandsRepository repository) : base(repository, "Brändid")
        {
        }

        protected internal override Brand ToObject(BrandView view) => BrandViewFactory.Create(view);
        
        protected internal override BrandView ToView(Brand obj) => BrandViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri("/Brands", UriKind.Relative);
    }
}
