using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class BaseObject
    {
        [DataMember(Order = 1)]
        public long ID { get; set; }
        [DataMember(Order = 2)]
        public string Name { get; set; }

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
