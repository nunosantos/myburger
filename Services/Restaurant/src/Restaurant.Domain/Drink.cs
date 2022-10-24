using Restaurant.Domain;

namespace Domain
{
    public class Drink : EntityBase
    {
        public string Name { get; set; }
        public int Price { get; set; }
    }
}