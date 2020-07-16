using DeveloperMeetupDomain.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeveloperMeetupDomain.Entities
{
    public abstract class BaseEntity<T> : IBaseEntity<T>
    {
        public T Id { get; set; }
        object IBaseEntity.Id
        {
            get { return Id; }
            set { _ = Id; }
        }

        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
    }
}
