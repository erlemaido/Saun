using System;
using System.ComponentModel.DataAnnotations;

namespace Facade.Abstractions
{
    public abstract class UniqueEntityView
    {
        public string Id { get; set; }

        public string GetId() => Id;
    }
}
