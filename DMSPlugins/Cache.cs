using System;
using System.Collections.Generic;
using System.Linq;

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
            foreach (var app in Cache.Applications)
            {
                try
                {
                    app.Application.Disconnect();
                }
                catch (Exception ex)
                {
                    int i = 0;
                }

            }
        }

        public static void Clear(string userName)
        {
            Applications.RemoveAll(x => x.UserName == userName);
          
        }
    }
}
