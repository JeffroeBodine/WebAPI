using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public class TaskOrigin:BaseObject
    {
       [DataMember]
       public virtual bool Active { get; set; }
    }
}
