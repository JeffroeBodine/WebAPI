using Faker;

namespace ObjectLibrary.SearchKeywords
{
    public class SearchKeyword : BaseObject
    {
        public virtual string Name { get; set; }

        public SearchKeyword()
        { }

        public SearchKeyword(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
