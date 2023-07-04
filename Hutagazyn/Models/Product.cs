namespace Hutagazyn.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Amount { get; set; }
        public int Price { get; set; }
        public ICollection<AdditionalOrderInfo> AdditionalOrderInfos { get; } = new List<AdditionalOrderInfo>();
        public Product()
        {
            
        }

    }
}
