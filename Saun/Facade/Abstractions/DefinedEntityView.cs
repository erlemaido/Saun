using System.ComponentModel;

namespace Facade.Abstractions
{
    public class DefinedEntityView : NamedEntityView
    {
        [DisplayName("Kirjeldus")]
        public string Description { get; set; }

    }
}