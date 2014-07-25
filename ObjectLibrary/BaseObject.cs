using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class BaseObject
    {
        public virtual long ID { get; set; }
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
