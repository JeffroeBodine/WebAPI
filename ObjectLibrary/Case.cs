using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public class Case : BaseObject
    {
        [DataMember]
        public virtual string CaseNumber { get; set; }
        [DataMember]
        public virtual string SecondaryCaseNumber { get; set; }
        [DataMember]
        public virtual long ProgramTypeId { get; set; }
        [DataMember]
        public virtual long CaseWorkerId { get; set; }
        [DataMember]
        public virtual long CaseHeadId { get; set; }

        [DataMember]
        public virtual IList<Client> Clients { get; set; }
    }
}
