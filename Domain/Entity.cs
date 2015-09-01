using System;

namespace Domain
{
    public class Entity
    {
        public virtual int Id { get; set; }

        public virtual string CreateUser { get; set; }

        public virtual DateTime CreateDate { get; set; }

        public virtual string ModifiedUser { get; set; }

        public virtual DateTime ModifiedDate { get; set; }
    }
}