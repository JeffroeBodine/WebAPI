using System.Collections.Generic;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
   public  class Address : BaseObject
    {
       [DataMember]
       public virtual string Street1 { get; set; }
       [DataMember]
       public virtual string Street2 { get; set; }
       [DataMember]
       public virtual string Street3 { get; set; }

       [DataMember]
       public virtual string City { get; set; }
       [DataMember]
       public virtual string State { get; set; }
       [DataMember]
       public virtual string Zip { get; set; }
       [DataMember]
       public virtual string Plus4 { get; set; }

       [DataMember]
       public virtual string AddressType { get; set; }

       //public virtual IList<Client> Clients { get; set; } 
    }

    public enum AddressType
    {
        Home = 1,
        Work = 2
    }
}
