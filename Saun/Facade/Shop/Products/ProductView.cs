﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Shop.Brands;
using Domain.Shop.ProductTypes;
using Domain.Shop.Units;
using Facade.Abstractions;

namespace Facade.Shop.Products
{
    public sealed class ProductView : DefinedEntityView
    {
        [Required]
        [DisplayName("Bränd")]
        public string BrandId { get; set; }
        public Brand Brand { get; set; }
        
        [Required]
        [DisplayName("Tüüp")]
        public string ProductTypeId { get; set; }
        public ProductType ProductType { get; set; }
        
        [Required]
        [DisplayName("Ühik")]
        public string UnitId { get; set; }
        public Unit Unit { get; set; }
        
        [Required]
        public string PictureUrl { get; set; }
        
        [Required]
        [DisplayName("Hind")]
        public double Price { get; set; }
    }
}
