namespace Data.Abstractions
{
    public abstract class NamedEntityData : UniqueEntityData
    {
        public string Name { get; set; }
    }
}