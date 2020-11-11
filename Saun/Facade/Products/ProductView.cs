using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.CatalogItems
{
    public class CatalogItemView : DefinedEntityView
    {
        [Required]
        [DisplayName("Bränd")]
        public Guid CatalogItemBrandId { get; set; }
        
        [Required]
        [DisplayName("Tüüp")]
        public Guid CatalogItemTypeId { get; set; }
        
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
