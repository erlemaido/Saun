using System;
using System.ComponentModel.DataAnnotations;

namespace Facade.Abstractions
{
    public abstract class UniqueEntityView
    {
        [Required]
        public String Id { get; set; }

        public String GetId() => Id;
        
    }
}
