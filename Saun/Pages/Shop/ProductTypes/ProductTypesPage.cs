﻿using System;
using Data.Shop.ProductTypes;
using Domain.Shop.ProductTypes;
using Facade.Shop.ProductTypes;
using Microsoft.AspNetCore.Mvc;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.ProductTypes
{
    public sealed class ProductTypesPage : ViewsPage<IProductTypesRepository, ProductType, ProductTypeView, ProductTypeData>
    {
        public ProductTypesPage(IProductTypesRepository productTypesRepository) : base(productTypesRepository, PagesNames.ProductTypes)
        {
        }
        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.ProductTypes, UriKind.Relative);

        protected internal override ProductType ToObject(ProductTypeView view) => ProductTypeViewFactory.Create(view);

        protected internal override ProductTypeView ToView(ProductType obj) => ProductTypeViewFactory.Create(obj);
    
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new ProductTypeView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}
