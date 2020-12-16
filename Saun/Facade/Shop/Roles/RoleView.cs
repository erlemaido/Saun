using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.Roles
{
    public class RoleView : DefinedEntityView
    {
        [Required]
        [DisplayName("Kehtiv alates")]
        public DateTime ValidFrom { get; set; }
        
        [DisplayName("Kehtiv kuni")]
        public DateTime ValidTo { get; set; }
    }
}
