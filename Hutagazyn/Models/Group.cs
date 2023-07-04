namespace Hutagazyn.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string DeliveryHour { get; set; }
        public string Carrier { get; set; }
        public virtual ICollection<Order> Orders { get; } = new List<Order>();
        public Group()
        {
            
        }
    }
}
