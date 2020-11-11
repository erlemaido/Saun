using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Products
{
    public class ProductView : DefinedEntityView
    {
        [Required]
        [DisplayName("Bränd")]
        public Guid BrandId { get; set; }
        
        [Required]
        [DisplayName("Tüüp")]
        public Guid ProductTypeId { get; set; }
        
        [Required]
        [DisplayName("Ühik")]
        public Guid UnitId { get; set; }
        
        [Required]
        public string PictureUrl { get; set; }
        
        [Required]
        [DisplayName("Hind")]
        public double Price { get; set; }
    }
}
