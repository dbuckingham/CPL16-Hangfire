using System;

namespace Core.Data
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
    }
}
