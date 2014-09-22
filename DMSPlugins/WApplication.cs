using Hyland.Unity;

namespace DMSPlugins
{
    public class WApplication
    {
        public string UserName { get; set; }
        public Application Application { get; set; }

        public WApplication(string userName, Application application)
        {
            UserName = userName;
            Application = application;
        }
    }
}
