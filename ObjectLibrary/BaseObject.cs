using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class BaseObject
    {
        [DataMember]
        public virtual long Id { get; set; }
        [DataMember]
        public virtual string Name { get; set; }

        public BaseObject()
        { 
        }

        public BaseObject(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
