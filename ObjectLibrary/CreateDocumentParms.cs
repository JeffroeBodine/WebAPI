using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class CreateDocumentParms
    {
        [DataMember]
        public long DocumentTypeId { get; set; }
        [DataMember]
        public List<Keyword> Keywords { get; set; }

        public CreateDocumentParms()
        {
            Keywords = new List<Keyword>();
        }
    }
}
