using System.ComponentModel;

namespace ObjectLibrary
{
    public enum TaskOrigin
    {
        Fax = 1,
        [Description("Capture Scan")]
        CaptureScan = 2,
        [Description("Phone Call")]
        PhoneCall = 3,
        Email = 4,
        Mail = 5,
        Inactive = 6,
        [Description("Walk In Request")]
        WalkInRequest = 7
    }
}
