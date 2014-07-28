using System;
using System.Collections.Generic;

namespace ObjectLibrary
{
    public class Client : BaseObject
    {
        public virtual string CompassNumber { get; set; }
        public virtual string SSN { get; set; }
        public virtual string Suffix { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string MiddleName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string MaidenName { get; set; }

        public virtual string StateIssuedNumber { get; set; }
        public virtual string SISNumber { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string BirthLocation { get; set; }
        public virtual string Gender { get; set; }

        public virtual string HomePhone { get; set; }
        public virtual string CellPhone { get; set; }
        public virtual string WorkPhone { get; set; }

        //public virtual IList<Address> Addresses { get; set; }

        //public virtual string Education { get; set; }
       
        //public virtual string Marraige { get; set; }
        //public virtual string Military { get; set; }
        
    }
}
