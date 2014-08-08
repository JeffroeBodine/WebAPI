using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public class Case : BaseObject
    {
        public virtual string CaseNumber { get; set; }
        public virtual string SecondaryCaseNumber { get; set; }
        public virtual long ProgramTypeId { get; set; }
        public virtual long CaseWorkerId { get; set; }
        public virtual long CaseHeadId { get; set; }

        public virtual IList<Client> Clients { get; set; }
    }
}
