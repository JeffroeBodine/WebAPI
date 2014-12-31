using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public class ProgramType : BaseObject
    {
        [DataMember]
        public virtual string Name { get; set; }
    }
}
