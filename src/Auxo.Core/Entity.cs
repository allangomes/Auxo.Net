using System;

namespace Auxo.Core
{
    public class Entity
    {
        public Guid Id { get; set; }
        public static implicit operator bool(Entity entity) => entity != null;
    }
}