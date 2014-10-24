using System;

namespace ObjectLibrary
{
    public class Task : BaseObject
    {
  
        public virtual string Description { get; set; }
        public virtual string Note { get; set; }
        public virtual DateTime DueDate { get; set; }
        public virtual DateTime StartDate { get; set; }
        public virtual DateTime EndDate { get; set; }
        public virtual bool GroupTask { get; set; }

        public virtual TaskPriority Priority { get; set; }
        public virtual TaskType TaskType { get; set; }
        public virtual TaskStatus Status { get; set; }
        public virtual TaskOrigin Origin { get; set; }
    }
}
