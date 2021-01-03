using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.Users
{
    public sealed class UserView : UniqueEntityView
    {
        [Required]
        [DisplayName("Klient")]
        public string PersonId { get; set; }

        [Required]
        [DisplayName("Kas Email on kinnitatud")]
        public bool EmailConfirmed { get; set; }
        
        [Required]
        [DisplayName("Salasõna räsi")]
        public string PasswordHash { get; set; }
        
        [Required]
        [DisplayName("Kehtiv alates")]
        public DateTime ValidFrom { get; set; }
        
        [DisplayName("kehtiv kuni")]
        public DateTime ValidTo { get; set; }
        
        [DisplayName("Kommentaar")]
        public string Comment { get; set; }
    }
}
