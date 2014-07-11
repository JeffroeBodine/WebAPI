using ObjectLibrary;
using ObjectLibrary.Collections;

namespace DMSPlugins.OnBase13
{
    public class OnBase
    {
        private const string ServiceURL = "http://vm-qatrunk-ob13/AppServer/Service.asmx";
        private const string DataSource = "OBSERVER";

        private readonly OnBaseUnityModel _model;

        public OnBase(string userName, string password)
        {
            _model = new OnBaseUnityModel(ServiceURL,DataSource, userName, password.Secure());
        }

        public  DocumentTypes GetDocumentTypes()
        {
            return _model.GetDocumentTypes();
        }
    }
}
