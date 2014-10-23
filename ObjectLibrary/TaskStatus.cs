using System.ComponentModel;

namespace ObjectLibrary
{
    public enum TaskStatus
    {

        Assigned = 1,
        [Description("In Progress")]
        InProgress = 2,
        Complete = 3
    }
}
