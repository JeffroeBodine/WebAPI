namespace ObjectLibrary
{
    public class TaskType : BaseObject
    {
        public virtual int DefaultDueMinutes { get; set; }
        public virtual bool DefaultGroupTask { get; set; }
        public virtual TaskPriority DefaultPriority { get; set; }
        public virtual TaskDueDateCalculation DueDateCalculation { get; set; }
    }
}