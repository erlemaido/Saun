using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Data.Shop.OrderItems;
using Domain.Shop.OrderItems;
using Facade.Abstractions;

namespace Facade.Shop.Orders
{
    public sealed class OrderView : UniqueEntityView
    {
        [Required]
        [DisplayName("Nimi")]
        public string Name { get; set; }
        
        [DisplayName("Klient")]
        public string PersonId { get; set; }
        
        [DisplayName("Kasutaja")]
        public string UserId { get; set; }
        
        [Required]
        [DisplayName("Tarne tüüp")]
        public string DeliveryTypeId { get; set; }
        
        [DisplayName("Riik")]
        public string CountryId { get; set; }
        
        [DisplayName("Linn")]
        public string CityId { get; set; }
        
        [DisplayName("Tänav")]
        public string Street { get; set; }
        
        [DisplayName("Postiindeks")]
        public string ZipCode { get; set; }
        
        [Required]
        [DisplayName("Hind")]
        public double TotalPrice { get; set; }
        
        [Required]
        [DisplayName("Tellimuse kuupäev")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Saate kulu")]
        public double DeliveryCost { get; set; }
        
        [DisplayName("Kommentaar")] 
        public string Comment { get; set; }
        
        public List<OrderItemData> OrderItems { get; set; }
    }
}
