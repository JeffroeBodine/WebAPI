using Newtonsoft.Json;

namespace WebAPI.Models
{
    public abstract class BaseObject
    {
        [JsonProperty(Order=1)]
        public virtual long ID { get; set; }
        [JsonProperty(Order = 2)]
        public virtual string Name { get; set; }

        protected BaseObject()
        {
        }

        protected BaseObject(long id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}