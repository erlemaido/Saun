using System;
using Data.Products;
using Facade.Products;
using Domain.Products;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using Domain.Brands;
using Domain.ProductTypes;
using Domain.Units;
using Data.Brands;
using Data.ProductTypes;
using Data.Units;

namespace Pages.Products
{
    public class ProductsPage : ViewPage<IProductsRepository, Product, ProductView, ProductData>
    {
        public IEnumerable<SelectListItem> Brands { get; }
        public IEnumerable<SelectListItem> ProductTypes { get; }
        public IEnumerable<SelectListItem> Units { get; }

        public ProductsPage(IProductsRepository repository, IBrandsRepository brandsRepository, IProductTypesRepository productTypesRepository, IUnitsRepository unitsRepository) : base(repository, "Tooted")
        {
            Brands = NewItemsList<Brand, BrandData>(brandsRepository);
            ProductTypes = NewItemsList<ProductType, ProductTypeData>(productTypesRepository);
            Units = NewItemsList<Unit, UnitData>(unitsRepository);
        }

        public string BrandName(Guid id) => ItemName(Brands, id);

        public string ProductTypeName(Guid id) => ItemName(ProductTypes, id);

        public string UnitName(Guid id) => ItemName(Units, id);


        protected internal override Product ToObject(ProductView view) => ProductViewFactory.Create(view);

        protected internal override ProductView ToView(Product obj) => ProductViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri("/Products", UriKind.Relative);
    }
}

