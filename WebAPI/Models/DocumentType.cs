using Newtonsoft.Json;
using WebAPI.Models.Collections;

namespace WebAPI.Models
{
    public class DocumentType : BaseObject
    {
        [JsonProperty(Order = 10)]
        public DocumentTypes DocumentTypes { get; set; }

        public DocumentType(long id, string name)
        {
            ID = id;
            Name = name;
            DocumentTypes = new DocumentTypes();
        }

        public DocumentType(long id, string name, DocumentTypes documentTypes)
            : base(id, name)
        {
            DocumentTypes = documentTypes;
        }
    }
}