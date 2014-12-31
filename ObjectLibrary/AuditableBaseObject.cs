using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class AuditableBaseObject<T> : IAuditableBaseObject
    {
        [DataMember]
        public virtual long Id { get; set; }

        [DataMember]
        public virtual string AuditUser { get; set; }
        [DataMember]
        public virtual DateTime AuditDate { get; set; }
        [DataMember]
        public virtual string MACAddress { get; set; }
        [DataMember]
        public virtual string IPAddress { get; set; }

        protected AuditableBaseObject()
        {
        }

        public AuditableBaseObject(long id)
        {
            Id = id;
        }

        string IAuditableBaseObject.CreateDatePropertyName
        {
            get
            {
                string createdPropName = "AuditDate";

#if DEBUG
                CheckIfPropertyExists(createdPropName);
#endif

                return createdPropName;
            }
        }

        string IAuditableBaseObject.ModifiedDatePropertyName
        {
            get
            {
                string modifiedPropName = "ModifiedDate";

#if DEBUG
                CheckIfPropertyExists(modifiedPropName);
#endif

                return modifiedPropName;
            }
        }

        private void CheckIfPropertyExists(string propertyName)
        {
            PropertyInfo pi = this.GetType().GetProperty(propertyName);
            Debug.Assert(pi != null, String.Format("There exists no property {0}", propertyName));
        }
    }

  
}
