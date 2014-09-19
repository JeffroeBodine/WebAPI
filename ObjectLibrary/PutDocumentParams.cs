using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class PutDocumentParams
    {
        [DataMember]
        public long DocumentTypeId { get; set; }
        [DataMember]
        public List<Keyword> Keywords { get; set; }

        public PutDocumentParams()
        {
            Keywords = new List<Keyword>();
        }

        public PutDocumentParams(long documentTypeId): this()
        {
            DocumentTypeId = documentTypeId;
        }

        public PutDocumentParams(long documentTypeId, List<Keyword> keywords) : this(documentTypeId)
        {
            Keywords = keywords;
        }
    }
}
