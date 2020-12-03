using System;
using System.Collections.Generic;
using Aids.Reflection;
using Data.Brands;
using Data.Products;
using Data.ProductTypes;
using Data.Units;
using Domain.Brands;
using Domain.Products;
using Domain.ProductTypes;
using Domain.Units;
using Facade.Brands;
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
            Units = NewUnitsList<Unit, UnitData>(unitsRepository);
        }

        public string GetBrandName(string id) => GetItemName(Brands, id);

        public string GetProductTypeName(string id) => GetItemName(ProductTypes, id);
        
        public string GetUnitName(string id) => GetItemName(Units, id);
        

        protected internal override Product ToObject(ProductView view) => ProductViewFactory.Create(view);

        protected internal override ProductView ToView(Product obj) => ProductViewFactory.Create(obj);

        protected internal override Uri CreatePageUrl() => new Uri(PagesUrls.Products, UriKind.Relative);


        private bool IsBrand() => FixedFilter == GetMember.Name<ProductView>(x => x.BrandId);
        
        private bool IsProductType() => FixedFilter == GetMember.Name<ProductView>(x => x.ProductTypeId);

        protected internal override string GetPageSubtitle()
        {
            if (IsBrand())
            {
                return $"{GetBrandName(FixedValue)}";
            }
            else if (IsProductType())
            {
                return $"{GetProductTypeName(FixedValue)}";
            }
            else
            {
                return "Määramata alalehe pealkiri";
            }
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

