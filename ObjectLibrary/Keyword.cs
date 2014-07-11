using System;
using System.Runtime.Serialization;

namespace ObjectLibrary
{
    [DataContract]
    public class Keyword
    {
        [DataMember(Order = 100)]
        public bool IsBlank { get; set; }
        [DataMember(Order = 101)]
        public string StringValue { get; set; }
        [DataMember(Order = 102)]
        public DateTime DateTimeValue { get; set; }
        [DataMember(Order = 103)]
        public int IntValue { get; set; }
        [DataMember(Order = 104)]
        public long LongValue { get; set; }
        [DataMember(Order = 105)]
        public double DoubleValue { get; set; }
        [DataMember(Order = 106)]
        public decimal DecimalValue { get; set; }
        [DataMember(Order = 107)]
        public Object Value { get; set; }
        [DataMember(Order = 108)]
        public KeywordType KeywordType { get; set; }


        public Keyword(KeywordType keywordType, string value)
        {
            KeywordType = keywordType;
            StringValue = value;
            Value = value;
        }

        public Keyword(KeywordType keywordType, DateTime value)
        {
            KeywordType = keywordType;
            DateTimeValue = value;
            Value = value;
        }

        public Keyword(KeywordType keywordType, int value)
        {
            KeywordType = keywordType;
            IntValue = value;
            Value = value;
        }

        public Keyword(KeywordType keywordType, long value)
        {
            KeywordType = keywordType;
            LongValue = value;
            Value = value;
        }

        public Keyword(KeywordType keywordType, double value)
        {
            KeywordType = keywordType;
            DoubleValue = value;
            Value = value;
        }

        public Keyword(KeywordType keywordType, decimal value)
        {
            KeywordType = keywordType;
            DecimalValue = value;
            Value = value;
        }
    }
}
