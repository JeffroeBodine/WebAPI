using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class PutDocumentMetaData
    {
        [DataMember(Order = 100)]
        public string Extension { get; set; }
        [DataMember(Order = 101)]
        public string MimeType { get; set; }
        [DataMember(Order = 102)]
        public int PageCount { get; set; }
        [DataMember(Order = 102)]
        public string Junk { get; set; }

        public PutDocumentMetaData(string extension, string mimeType, int pageCount, string junk)
        {
            Extension = extension;
            MimeType = mimeType;
            PageCount = pageCount;
            Junk = junk;
        }

       
    }
}
