using Hyland.Unity;

namespace DMSPlugins
{
    public class CachedApplication
    {
        public string UserName { get; set; }
        public Application Application { get; set; }

        public CachedApplication(string userName, Application application)
        {
            UserName = userName;
            Application = application;
        }
    }
}
