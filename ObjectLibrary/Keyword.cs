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
        //[DataMember(Order = 102)]
        public DateTime DateTimeValue { get; set; }
        [DataMember(Order = 103)]
        public int IntValue { get; set; }
        [DataMember(Order = 104)]
        public long LongValue { get; set; }
        [DataMember(Order = 105)]
        public double DoubleValue { get; set; }
        [DataMember(Order = 106)]
        public decimal DecimalValue { get; set; }
        [DataMember(Order = 108)]
        public KeywordType KeywordType { get; set; }

        public Keyword()
        {
        }

        public Keyword(KeywordType keywordType, string value)
        {
            KeywordType = keywordType;
            StringValue = value;
        }

        public Keyword(KeywordType keywordType, DateTime value)
        {
            KeywordType = keywordType;
            DateTimeValue = value;
        }

        public Keyword(KeywordType keywordType, int value)
        {
            KeywordType = keywordType;
            IntValue = value;
        }

        public Keyword(KeywordType keywordType, long value)
        {
            KeywordType = keywordType;
            LongValue = value;
        }

        public Keyword(KeywordType keywordType, double value)
        {
            KeywordType = keywordType;
            DoubleValue = value;
        }

        public Keyword(KeywordType keywordType, decimal value)
        {
            KeywordType = keywordType;
            DecimalValue = value;
        }
    }
}
