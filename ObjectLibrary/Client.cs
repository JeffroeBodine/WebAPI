using System;

namespace ObjectLibrary
{
    class Client : BaseObject
    {
        public virtual string CompassNumber { get; set; }
        public virtual string SSN { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }

        public virtual string StateIssuedNumber { get; set; }
        public virtual string SISNumber { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string BirthLocation { get; set; }
        //public virtual string Gender { get; set; }
       
        //public virtual string Education { get; set; }
        //public virtual string Phones { get; set; }
        //public virtual string Addresses { get; set; }
        //public virtual string Marraige { get; set; }
        //public virtual string Military { get; set; }
        
    }
}
