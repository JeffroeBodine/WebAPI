using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class BaseObject
    {
        [DataMember(Order = 1)]
        public virtual long ID { get; set; }
        [DataMember(Order = 2)]
        public virtual string Name { get; set; }

        public BaseObject()
        { 
        }

        public BaseObject(long id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}
