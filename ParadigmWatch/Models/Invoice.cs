using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class Invoice
    {
        private decimal totalPrice;
        public int InvoiceId { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "float")]
        public decimal TotalPrice { get; set; }
        public List<OrderItem> OrderItems { get; set; }

        public AppUser User { get; set; }

        public Invoice()
        {
        }

        public void AddOrderItem(Watch watch, int quantity)
        {
            this.OrderItems.Add(new OrderItem(watch, quantity));
        }
    }
}
