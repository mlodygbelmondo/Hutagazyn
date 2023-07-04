using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace Hutagazyn.Models
{
    public class AdditionalOrderInfo
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; } = null!;
        public int OrderId { get; set; }
        public virtual Order Order { get; set; } = null!;
        public AdditionalOrderInfo()
        {


        }
    }
    public class Order
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public int GroupId { get; set; }
        public virtual Group Group { get; set; } = null!;
        public int DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; } = null!;

        public virtual ICollection<AdditionalOrderInfo> AdditionalOrderInfos { get; } = new List<AdditionalOrderInfo>();
        public Order()
        {

        }
    }
}


