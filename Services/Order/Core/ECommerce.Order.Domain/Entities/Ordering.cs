using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce.Order.Domain.Entities
{
    public class Ordering
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice 
        { 
            get
            {
               return OrderDetails?.Sum(x => x.ProductPrice * x.Quantity)?? 0 ;
            } 
        } 
        public DateTime OrderDate { get; set; }


        public IList<OrderDetail> OrderDetails { get; set; }


    }
}
