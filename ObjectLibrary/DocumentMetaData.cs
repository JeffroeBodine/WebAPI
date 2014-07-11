using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class DocumentMetaData
    {
        [DataMember(Order = 100)]
        public string Extension { get; set; }
        [DataMember(Order = 101)]
        public string MimeType { get; set; }
        [DataMember(Order = 102)]
        public int PageCount { get; set; }

        public DocumentMetaData(string extension, string mimeType, int pageCount)
        {
            Extension = extension;
            MimeType = mimeType;
            PageCount = pageCount;
        }
    }
}
