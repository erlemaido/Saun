using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.UserRoles
{
    public sealed class UserRoleView : UniqueEntityView
    {
        [Required]
        [DisplayName("Kasutaja")]
        public string UserId { get; set; }
        
        [Required]
        [DisplayName("Roll")]
        public string RoleId { get; set; }
        
        [Required]
        [DisplayName("Kehtiv alates")]
        public DateTime ValidFrom { get; set; }
        
        [DisplayName("Kehtiv kuni")]
        public DateTime ValidTo { get; set; }
        
        [DisplayName("Kommentaar")]
        public string Comment { get; set; }
    }
}
