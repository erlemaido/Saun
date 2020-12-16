using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.Reviews
{
    public class ReviewView : UniqueEntityView
    {
        [Required]
        [DisplayName("Toode")]
        public string ProductId { get; set; }
        
        [Required]
        [DisplayName("Klient")]
        public string UserId { get; set; }
        
        [Required]
        [DisplayName("Hinnang")]
        public int Rating { get; set; }

        [DisplayName("Kommentaar")]
        public string Comment { get; set; }
        
        [Required]
        [DisplayName("Kuupäev")]
        public DateTime Time { get; set; }
    }
}
