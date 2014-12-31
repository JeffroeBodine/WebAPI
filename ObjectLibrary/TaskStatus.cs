using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public class TaskStatus : BaseObject
    {
        [DataMember]
        public virtual string Description { get; set; }
    }
}
