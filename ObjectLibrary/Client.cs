using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public class Client : BaseObject
    {
        [DataMember]
        public virtual string CompassNumber { get; set; }
        [DataMember]
        public virtual string SSN { get; set; }
        [DataMember]
        public virtual string Suffix { get; set; }
        [DataMember]
        public virtual string FirstName { get; set; }
        [DataMember]
        public virtual string MiddleName { get; set; }
        [DataMember]
        public virtual string LastName { get; set; }
        [DataMember]
        public virtual string MaidenName { get; set; }

        [DataMember]
        public virtual string StateIssuedNumber { get; set; }
        [DataMember]
        public virtual string SISNumber { get; set; }
        [DataMember]
        public virtual DateTime BirthDate { get; set; }
        [DataMember]
        public virtual string BirthLocation { get; set; }
        [DataMember]
        public virtual string Gender { get; set; }

        [DataMember]
        public virtual string HomePhone { get; set; }
        [DataMember]
        public virtual string CellPhone { get; set; }
        [DataMember]
        public virtual string WorkPhone { get; set; }
       
    }
}
