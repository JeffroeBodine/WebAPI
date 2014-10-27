using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public class Task : BaseObject
    {
  
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public virtual string Note { get; set; }
        [DataMember]
        public virtual DateTime DueDate { get; set; }
        [DataMember]
        public virtual DateTime StartDate { get; set; }
        [DataMember]
        public virtual DateTime EndDate { get; set; }
        [DataMember]
        public virtual bool GroupTask { get; set; }

        [DataMember]
        public virtual TaskPriority Priority { get; set; }
        [DataMember]
        public virtual TaskType TaskType { get; set; }
        [DataMember]
        public virtual TaskStatus Status { get; set; }
        [DataMember]
        public virtual TaskOrigin Origin { get; set; }
    }
}
