namespace FinestSolutions.DomainDrivenDesign.Abstractions.Entities
{
    public abstract class Entity
    {
    }

    public abstract class Entity<TIdentifier> : Entity
    {
        public TIdentifier Id { get; protected set; }
    }
}