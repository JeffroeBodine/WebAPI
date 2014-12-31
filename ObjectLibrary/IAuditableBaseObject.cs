using System;

namespace ObjectLibrary
{
    public interface IAuditableBaseObject
    {
        string AuditUser { get; set; }
        DateTime AuditDate { get; set; }

        string IPAddress { get; set; }
        string MACAddress { get; set; }

        string CreateDatePropertyName { get; }
        string ModifiedDatePropertyName { get; }
    }
}
