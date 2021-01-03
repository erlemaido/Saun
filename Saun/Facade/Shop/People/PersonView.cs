using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Facade.Abstractions;

namespace Facade.Shop.People
{
    public sealed class PersonView : UniqueEntityView
    {
        [Required]
        [DisplayName("Eesnimi")]
        public string FirstName { get; set; }
        
        [Required]
        [DisplayName("Perekonnanimi")]
        public string LastName { get; set; }
        
        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }
    }
}
