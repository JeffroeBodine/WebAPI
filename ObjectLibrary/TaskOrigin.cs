using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public class TaskOrigin : BaseObject
    {
        [DataMember]
        public virtual string TaskOriginName { get; set; }
        [DataMember]
        public virtual bool Active { get; set; }
    }
}
