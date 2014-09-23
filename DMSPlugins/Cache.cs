using System.Collections.Generic;
using System.Linq;
using ObjectLibrary;

namespace DMSPlugins
{
    public static class Cache
    {
        public static List<WApplication> Applications;

        static Cache()
        {
            if (Applications == null)
                Applications = new List<WApplication>();
        }

        public static void Clear()
        {
            Applications.ForEach(x=> x.Application.Disconnect());
            Applications = new List<WApplication>();
        }

        public static void Clear(string userName)
        {
            Applications.Where(x => x.UserName == userName).ForEach(x => x.Application.Disconnect());
            Applications.RemoveAll(x => x.UserName == userName);
        }
    }
}
