using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    public enum KeywordTypes
    {
        FirstName = 104,
        LastName = 105,
        SSN = 103,
        CompassNumber = 136,
    }

    [DataContract]
    public class KeywordType : BaseObject
    {
        [DataMember(Order = 100)]
        public virtual string Name { get; set; }

        [DataMember(Order = 100)]
        public string DataTypeString {
            get { return DataType.ToString(); }
            set { DataType = Type.GetType(value); }
        }
      
        [DataMember(Order = 101)]
        public string DefaultValue { get; set; }

        private Type DataType { get; set; }

        public KeywordType(long id, string name, Type dataType, string defaultValue)
        {
            Id = id;
            Name = name;
            DataType = dataType;
            DefaultValue = defaultValue;
        }
    }
}
