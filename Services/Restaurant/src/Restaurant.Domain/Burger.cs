using Restaurant.Domain;

namespace Domain
{
    public class Burger : EntityBase
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }
}