using System;

namespace Todo.Domain.Entities
{
    public abstract class Entity: IEquatable<Entity>
    {
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; private set; } //Pouca performance em relação ao ID do sql server

        public bool Equals(Entity other)
        {
            return Id == other.Id;
        }
    }
}