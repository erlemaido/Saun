using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Aids.Reflection;
using Data.Shop.Brands;
using Data.Shop.Products;
using Data.Shop.ProductTypes;
using Data.Shop.Reviews;
using Data.Shop.Units;
using Domain.Shop.BasketItems;
using Domain.Shop.Brands;
using Domain.Shop.Products;
using Domain.Shop.ProductTypes;
using Domain.Shop.Reviews;
using Domain.Shop.Stock;
using Domain.Shop.Units;
using Facade.Shop.Products;
using Facade.Shop.Reviews;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Sauna.Pages.Abstractions;
using Sauna.Pages.Abstractions.Constants;

namespace Sauna.Pages.Shop.Products
{
    [IgnoreAntiforgeryToken(Order = 1001)]
    public sealed class ProductsPage : ViewPage<IProductsRepository, Product, ProductView, ProductData>
    {
        
        public List<Domain.Shop.Stock.Stock> Stock { get; }
        public IEnumerable<SelectListItem> Brands { get; }
        public IEnumerable<SelectListItem> ProductTypes { get; }
        public IEnumerable<SelectListItem> Units { get; }
        public IList<ReviewView> Reviews { get; }
        private readonly IReviewsRepository reviews;
        
        private IHostingEnvironment _environment;

        public List<BasketItem> Cart { get; set; }
        
        [BindProperty]
        public IFormFile Upload { get; set; }

        public ProductsPage(
            IHostingEnvironment environment,
            IStockRepository stockRepository,
            IProductsRepository repository, 
            IBrandsRepository brandsRepository, 
            IProductTypesRepository productTypesRepository, 
            IReviewsRepository reviewsRepository,
            IUnitsRepository unitsRepository) : base(repository, PagesNames.Products)
        {
            _environment = environment;
            Stock = stockRepository.Get().Result;
            Brands = NewItemsList<Brand, BrandData>(brandsRepository);
            ProductTypes = NewItemsList<ProductType, ProductTypeData>(productTypesRepository);
            Units = NewUnitsList<Unit, UnitData>(unitsRepository);
            Reviews = new List<ReviewView>();
            reviews = reviewsRepository;
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

        public override async Task<IActionResult> OnPostCreateAsync(
            string sortOrder,
            string searchString,
            int? pageIndex,
            string fixedFilter,
            string fixedValue)
        {
            UploadFile();
            
            if (!await AddObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue)
                .ConfigureAwait(true)) return Page();

            return Redirect(IndexUrl.ToString());
        }
        
        public override async Task<IActionResult> OnPostEditAsync(string sortOrder, string searchString, int pageIndex,
            string fixedFilter, string fixedValue)
        {
            UploadFile();

            await UpdateObject(sortOrder, searchString, pageIndex, fixedFilter, fixedValue).ConfigureAwait(true);

            return Redirect(IndexUrl.ToString());
        }

        private async void UploadFile()
        {
            var file = Path.Combine(_environment.ContentRootPath, "wwwroot\\uploads", Upload.FileName);
            using (var fileStream = new FileStream(file, FileMode.Create))
            {
                await Upload.CopyToAsync(fileStream);
            }
            Item.PictureUrl = Upload.FileName;
        }

        //TODO: see kasutab hetkel toorest Review aga ilmselt peaks kasutama ReviewOfProduct vms
        public void AddReview(ProductView item)
        {
            Reviews.Clear();

            if (item is null) return;
            reviews.FixedFilter = GetMember.Name<ReviewData>(x => x.ProductId);
            reviews.FixedValue = item.Id;
            var list = reviews.Get().GetAwaiter().GetResult();

            foreach (var e in list)
            {
                Reviews.Add(ReviewViewFactory.Create(e));
            }
        }
    }
}
