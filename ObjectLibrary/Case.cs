using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class Case : BaseObject
    {
        [DataMember]
        public virtual string CaseNumber { get; set; }
        [DataMember]
        public virtual string SecondaryCaseNumber { get; set; }
        [DataMember]
        public virtual decimal ProgramTypeId { get; set; }
        [DataMember]
        public virtual decimal CaseWorkerId { get; set; }
        [DataMember]
        public virtual decimal CaseHeadId { get; set; }
    }
}
