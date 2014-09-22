using System.Collections.Generic;

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
    }
}
