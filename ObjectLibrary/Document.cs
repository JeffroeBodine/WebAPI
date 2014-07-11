using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public sealed class Document : BaseObject
    {
        [DataMember(Order = 100)]
        public DateTime CreateDate { get; set; }

        [DataMember(Order = 101)]
        public DateTime LUPDate { get; set; }

        [DataMember(Order = 102)]
        public string Author { get; set; }

        [DataMember(Order = 103)]
        public long DocumentTypeID { get; set; }

        [DataMember(Order = 104)]
        public DocumentMetaData MetaData { get; set; }

        public Document(long id, string name, DateTime createDate, DateTime lupDate, string author, long documentTypeID)
            : base(id, name)
        {
            CreateDate = createDate;
            LUPDate = lupDate;
            Author = author;
            DocumentTypeID = documentTypeID;
        }

        public Document(long id, string name, DateTime createDate, DateTime lupDate, string author, long documentTypeID, DocumentMetaData metaData)
            : this(id, name, createDate, lupDate, author, documentTypeID)
        {
            MetaData = metaData;
        }
    }
}
