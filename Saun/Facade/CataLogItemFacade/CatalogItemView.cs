using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Saun.Facade.Abstractions;

namespace Saun.Facade.CataLogItemFacade
{
    public class CatalogItemView : DefinedEntityView
    {
        [Required]
        [DisplayName("Bränd")]
        public Guid CatalogItemBrandId { get; set; }
        [Required]
        [DisplayName("Toote tüüp")]
        public Guid CatalogItemTypeId { get; set; }
        [Required]
        public Guid UnitId { get; set; }
        public string PictureUrl { get; set; } = null!;
        [Required]
        [DisplayName("Hind")]
        public double Price { get; set; }
        //public string GetId()
        //{
        //    return $"{CatalogItemBrandId}.{CatalogItemTypeId}.{UnitId}";
        //}
        //ei tea kumba tarvis on
        public Guid GetId()
        {
            return Id;
        }




    }
}
