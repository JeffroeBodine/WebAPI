using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public abstract class BaseObject
    {
        [DataMember]
        public virtual long Id { get; set; }

        protected BaseObject()
        { 
        }

        protected BaseObject(long id)
        {
            Id = id;
        }
    }
}
