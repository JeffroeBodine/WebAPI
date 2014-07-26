namespace ObjectLibrary
{
    public class Case : BaseObject
    {
        public virtual string CaseNumber { get; set; }
        public virtual string SecondaryCaseNumber { get; set; }
        public virtual ProgramType ProgramType{ get; set; }
        public virtual decimal CaseWorkerId { get; set; }
        public virtual decimal CaseHeadId { get; set; }
    }
}
