using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models
{
    public class Invoice
    {
        private decimal totalPrice = 0m;
        public int InvoiceId { get; set; }
        public DateTime OrderDate { get; set; }
        [Column(TypeName = "float")]
        public decimal TotalPrice { get { return this.totalPrice; } }
        public List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public AppUser User { get; set; }

        public Invoice()
        {
        }

        public void AddOrderItem(Watch watch, int quantity)
        {
            this.OrderItems.Add(new OrderItem(watch, quantity));
            this.totalPrice += this.OrderItems.Last().TotalPrice;
        }
    }
}
