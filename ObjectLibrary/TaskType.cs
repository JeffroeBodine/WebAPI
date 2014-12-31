using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class TaskType : BaseObject
    {
        [DataMember]
        public virtual string Description { get; set; }
        [DataMember]
        public virtual int DefaultDueMinutes { get; set; }
        [DataMember]
        public virtual bool DefaultGroupTask { get; set; }
        [DataMember]
        public virtual TaskPriority DefaultPriority { get; set; }
        [DataMember]
        public virtual TaskDueDateCalculation DueDateCalculation { get; set; }
    }
}