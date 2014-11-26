using System.Runtime.Serialization;

namespace ObjectLibrary.Connect
{
    public class ConnectType : BaseObject
    {
        [DataMember]
        public virtual bool Enabled { get; set; }
        [DataMember]
        public virtual int Interval { get; set; }
        [DataMember]
        public virtual SyncProviderType SyncProviderType { get; set; }

        public ConnectType()
        {
        }

        public ConnectType(long id, string name)
        {
            Id = id;
            Name = name;
            Enabled = true;
            Interval = -1;
            SyncProviderType = SyncProviderType.AMAZONCLOUD;
        }
    }
}
