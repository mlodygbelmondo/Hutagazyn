namespace Hutagazyn.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Mass { get; set; }
        public int Price { get; set; }
        public Boolean IsSellable { get; set; }
        public Product()
        {
            
        }

    }
}
