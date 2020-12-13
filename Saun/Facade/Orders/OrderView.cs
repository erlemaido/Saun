using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Facade.Abstractions;

namespace Facade.Orders
{
    public class OrderView : UniqueEntityView
    {
        [Required]
        [DisplayName("Klient")]
        public string PersonId { get; set; }
        public string UserId { get; set; }
        [Required]
        [DisplayName("Tarne tüüp")]
        public string DeliveryTypeId { get; set; }
        [Required]
        [DisplayName("Linn")]
        public string DeliveryCityId { get; set; }
        [Required]
        [DisplayName("Tellimuse hind")]
        public double TotalPrice { get; set; }
        [Required]
        [DisplayName("Tellimuse Kuupäev")]
        public DateTime OrderDate { get; set; }
        [Required]
        [DisplayName("Tänav")]
        public string Street { get; set; }
        public string ZipCode { get; set; }
        [Required]
        [DisplayName("Saate kulu")]
        public double DeliveryCost { get; set; }

    }
}
