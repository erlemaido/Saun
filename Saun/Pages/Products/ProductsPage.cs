using System;
using System.Collections.Generic;
using Data.Brands;
using Data.Products;
using Data.ProductTypes;
using Data.Units;
using Domain.Brands;
using Domain.Products;
using Domain.ProductTypes;
using Domain.Units;
using Facade.Products;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Products
{
    public class ProductsPage : ViewPage<IProductsRepository, Product, ProductView, ProductData>
    {
        public IEnumerable<SelectListItem> Brands { get; }
        public IEnumerable<SelectListItem> ProductTypes { get; }
        public IEnumerable<SelectListItem> Units { get; }

        public ProductsPage(
            IProductsRepository repository, 
            IBrandsRepository brandsRepository, 
            IProductTypesRepository productTypesRepository, 
            IUnitsRepository unitsRepository) : base(repository, PagesNames.Products)
        {
            Brands = NewItemsList<Brand, BrandData>(brandsRepository);
            ProductTypes = NewItemsList<ProductType, ProductTypeData>(productTypesRepository);
            Units = NewItemsList<Unit, UnitData>(unitsRepository);
        }

        public string BrandName(string id) => ItemName(Brands, id);

        public string ProductTypeName(string id) => ItemName(ProductTypes, id);

        public string UnitName(string id) => ItemName(Units, id);

        protected internal override Product ToObject(ProductView view) => ProductViewFactory.Create(view);

        protected internal override ProductView ToView(Product obj) => ProductViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Products, UriKind.Relative);
        
        public string GetBrandName(string brandId)
        {
            foreach (var m in Brands)
            {
                if (m.Value == brandId)
                    return m.Text;
            }

            return "Määramata";
        }
        
        public string GetProductTypeName(string productTypeId)
        {
            foreach (var m in ProductTypes)
            {
                if (m.Value == productTypeId)
                    return m.Text;
            }

            return "Määramata";
        }
        
        public string GetUnitName(string unitId)
        {
            foreach (var m in Units)
            {
                if (m.Value == unitId)
                    return m.Text;
            }

            return "Määramata";
        }
        
        protected internal override string GetPageSubtitle()
        {
            if (!GetBrandName(FixedValue).Equals("Määramata"))
            {
                return FixedValue is null ? base.GetPageSubtitle() : $"{GetBrandName(FixedValue)}";
            } 
            if (!GetProductTypeName(FixedValue).Equals("Määramata"))
            {
                return FixedValue is null ? base.GetPageSubtitle() : $"{GetProductTypeName(FixedValue)}";
            }
            if (!GetUnitName(FixedValue).Equals("Määramata"))
            {
                return FixedValue is null ? base.GetPageSubtitle() : $"{GetUnitName(FixedValue)}";
            }

            return base.GetPageSubtitle();
        }
        
        public override IActionResult OnGetCreate(
            string sortOrder, string searchString, int? pageIndex,
            string fixedFilter, string fixedValue, int? switchOfCreate)
        {
            Item = new ProductView() {Id = Guid.NewGuid().ToString()};

            return base.OnGetCreate(sortOrder, searchString, pageIndex,
                fixedFilter, fixedValue, switchOfCreate);
        }
    }
}

