using System.Linq;
using System.Security;
using ObjectLibrary;
using ObjectLibrary.Collections;

namespace DMSPlugins.OnBase13
{
    public class OnBaseUnityModel
    {
        private string ServiceUrl { get; set; }
        private string DataSource { get; set; }
        private string UserName { get; set; }
        private SecureString Password { get; set; }

        public OnBaseUnityModel(string serviceURL, string dataSource, string userName, SecureString password)
        {
            ServiceUrl = serviceURL;
            DataSource = dataSource;
            UserName = userName;
            Password = password;
        }

        private Hyland.Unity.Application OBConnection(string serviceURL, string dataSource, string userName, SecureString password)
        {
            Hyland.Unity.OnBaseAuthenticationProperties onBaseAuthProperties = Hyland.Unity.Application.CreateOnBaseAuthenticationProperties(serviceURL, userName, password.Insecure(), dataSource);
            return Hyland.Unity.Application.Connect(onBaseAuthProperties);
        }

        public DocumentTypes GetDocumentTypes()
        {
            var documentTypes = new DocumentTypes();
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                foreach (var udtg in app.Core.DocumentTypeGroups)
                {
                    var dtg = new DocumentType(udtg.ID, udtg.Name);
                    documentTypes.Add(dtg);

                    if (udtg.DocumentTypes != null)
                    {
                        foreach (var udt in udtg.DocumentTypes)
                        {
                            if (dtg.DocumentTypes == null)
                                dtg.DocumentTypes = new DocumentTypes();

                            dtg.DocumentTypes.Add(new DocumentType(udt.ID, udt.Name));
                        }
                    }
                }
            }
            return documentTypes;
        }

        public DocumentType GetDocumentType(string id)
        {
            using (var app = OBConnection(ServiceUrl, DataSource, UserName, Password))
            {
                var obDocumentType = app.Core.DocumentTypes.Find(long.Parse(id));
                return new DocumentType(obDocumentType.ID, obDocumentType.Name);
            }
        }
    }
}
