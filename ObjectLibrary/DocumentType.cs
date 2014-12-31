using System.Runtime.Serialization;
using ObjectLibrary.Collections;

namespace ObjectLibrary
{
    public enum DocumentTypes
    {
        JeffroesDocType = 520,
    }

    [DataContract]
    public class DocumentType : BaseObject
    {

        [DataMember(Order = 100)]
        public virtual string Name { get; set; }
        [DataMember(Order = 101)]
        public DocumentTypeList DocumentTypeList { get; set; }

        public DocumentType()
        {
            DocumentTypeList = new DocumentTypeList();
        }

        public DocumentType(long id, string name) : base(id)
        {
            Name = name;
            DocumentTypeList = new DocumentTypeList();
        }

        public DocumentType(long id, string name, DocumentTypeList documentTypeList) : base(id)
        {
            Name = name;
            DocumentTypeList = documentTypeList;
        }
    }
}
