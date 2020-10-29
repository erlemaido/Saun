using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Stocks
{
    public class StockView : UniqueEntityView
    {
        [Required]
        [DisplayName("Toode")]
        public Guid CatalogItemId { get; set; }
        [Required]
        [DisplayName("Kogus")]
        public int InStock { get; set; }
        [DisplayName("Viimane uuendus")]
        public DateTime LastUpdateTime { get; set; }
        [DisplayName("Kommentaar")]
        public string? Comment { get; set; }

        public Guid GetId()
        {
            return Id;
        }
        //public string GetId()
        //{
        //    return $"{Id}.{CatalogItemId}";
        //}

    }
}
