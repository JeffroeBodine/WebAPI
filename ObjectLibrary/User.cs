using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class User : AuditableBaseObject<User>
    {
        [DataMember(Order = 100)]
        public virtual string UserName { get; set; }
        [DataMember(Order = 101)]
        public virtual string Password { get; set; }
        [DataMember(Order = 102)]
        public virtual string Salt { get; set; }
        [DataMember(Order = 103)]
        public virtual string EMail { get; set; }
        [DataMember(Order = 104)]
        public virtual string FirstName { get; set; }
        [DataMember(Order = 105)]
        public virtual string LastName { get; set; }
      
        public User()
        {
        }

        public User(long id, string userName, string password, string eMail, string firstName, string lastName): base(id)
        {
            UserName = userName;
            Password = password;
            EMail = eMail;
            FirstName = firstName;
            LastName = lastName;
        }

        public User(long id, string name, string password, string eMail, string firstName, string lastName, string salt): this(id, name,password, eMail, firstName, lastName)
        {
            Salt = salt;
        }
    }
}
