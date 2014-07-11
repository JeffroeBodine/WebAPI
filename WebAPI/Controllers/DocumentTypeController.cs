using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ObjectLibrary;

namespace WebAPI.Controllers
{
    public class DocumentTypeController : ApiController
    {
        /// <summary>
        /// Returns the collection of DocumentTypes.
        /// </summary>
        public IEnumerable<DocumentType> Get()
        {
            return FakeData;
        }

        /// <summary>
        /// Returns a specific DocumentType given an ID.
        /// </summary>
        public DocumentType Get(int id)
        {
            var dt = FakeData.FirstOrDefault(x => x.ID == id);
            return dt;
        }

        /// <summary>
        /// Creates an instance of a DocumentType.
        /// </summary>
        public void Post([FromBody]string value)
        {
        }

        /// <summary>
        /// Updates an instance of a DocumentType given an ID.
        /// </summary>
        public void Put(int id, [FromBody]string value)
        {
        }

        /// <summary>
        /// Deletes an instance of a DocumentType.
        /// </summary>
        public void Delete(int id)
        {
        }

        private IEnumerable<DocumentType> FakeData {
            get
            {
                var lstDocTypes = new List<DocumentType>();

                for (var i = 1; i <= 10; i++)
                {
                    var docType1 = new DocumentType(i, i.ToString());
                    req(docType1, 0);
                    lstDocTypes.Add(docType1);
                }
                return lstDocTypes;
            }
        }

        private DocumentType req(DocumentType docType, int levelsDeep)
        {
            DocumentType dt = null;
            for (var i = 1; i <= 10; i++)
            {
              dt= new DocumentType(docType.ID + 1, "req");
                docType.DocumentTypes.Add(dt);
            }
            if (levelsDeep <= 10)
                req(dt, levelsDeep + 1);
           
            return docType;

        }
    }
}