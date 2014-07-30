using System.Collections.Generic;

namespace ObjectLibrary
{
   public  class Address : BaseObject
    {
       public virtual string Street1 { get; set; }
       public virtual string Street2 { get; set; }
       public virtual string Street3 { get; set; }

       public virtual string City { get; set; }
       public virtual string State { get; set; }
       public virtual string Zip { get; set; }
       public virtual string Plus4 { get; set; }

       public virtual string AddressType { get; set; }

       //public virtual IList<Client> Clients { get; set; } 
    }

    public enum AddressType
    {
        Home = 1,
        Work = 2
    }
}
