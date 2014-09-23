using System.Runtime.Serialization;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    public enum DocumentTypes
    {
        JeffroesDocType = 520,
    }

    [DataContract]
    public sealed class DocumentType : BaseObject
    {
        [DataMember(Order = 10)]
        public DocumentTypeList DocumentTypeList { get; set; }

        public DocumentType()
        {
            DocumentTypeList = new DocumentTypeList();
        }

        public DocumentType(long id, string name) : base(id, name)
        {
            DocumentTypeList = new DocumentTypeList();
        }

        public DocumentType(long id, string name, DocumentTypeList documentTypeList) : base(id, name)
        {
            DocumentTypeList = documentTypeList;
        }
    }
}
