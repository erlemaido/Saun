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
        public Guid ProductId { get; set; }
        
        [Required]
        [DisplayName("Kogus")]
        public int InStock { get; set; }
        
        [Required]
        [DataType(DataType.DateTime)]
        [DisplayName("Viimati uuendatud")]
        public DateTime LastUpdateTime { get; set; }
        
        [DisplayName("Kommentaar")]
        [MaxLength(512)]
        public string Comment { get; set; }
    }
}
