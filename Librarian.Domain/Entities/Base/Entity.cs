using System;

namespace Librarian.Domain.Entities.Base
{
    public abstract class Entity
    {
        public Entity()
        {
            Uid = Guid.NewGuid();
        }

        public Guid Uid { get; set; }   
    }
}