using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class AuditableBaseObject<T> : BaseObject
    {
        [DataMember]
        public virtual string AuditUser { get; set; }
        [DataMember]
        public virtual string AuditApplication { get; set; }
       
        protected AuditableBaseObject()
        {
        }
        public AuditableBaseObject(long id)
        {
            Id = id;
        }

    }

  
}
