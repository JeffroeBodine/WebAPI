using System.Runtime.Serialization;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    [DataContract]
    public sealed class DocumentType : BaseObject
    {
        [DataMember]
        public DocumentTypes DocumentTypes { get; set; }

        public DocumentType(long id, string name) : base(id, name)
        {
            DocumentTypes = new DocumentTypes();
        }

        public DocumentType(long id, string name, DocumentTypes documentTypes) : base(id, name)
        {
            DocumentTypes = documentTypes;
        }
    }
}
