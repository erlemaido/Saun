﻿using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Domain.Shop.Products;
using Facade.Abstractions;

namespace Facade.Shop.Stock
{
    public sealed class StockView : UniqueEntityView
    {
        [Required]
        [DisplayName("Toode")]
        public string ProductId { get; set; }
        
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
