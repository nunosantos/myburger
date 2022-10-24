using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.IdGenerators;

namespace Domain
{
    public class Shop
    {
        [BsonId(IdGenerator = typeof(ObjectIdGenerator))]
        public ObjectId _Id { get; set; }

        [BsonElement("ShopId")]
        public string ShopId { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }

        [BsonElement("Menu")]
        public Menu Menu { get; set; }
    }
}