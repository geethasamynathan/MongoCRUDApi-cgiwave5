using MongoDB.Bson.Serialization.Attributes;

namespace MongoCRUDApi.Models
{
    public class Product
    {
        [BsonId]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
       
    }
}
