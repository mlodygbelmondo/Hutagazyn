namespace Hutagazyn.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Order> Orders { get; } = new List<Order>();

        public Delivery() { }
    }
}
