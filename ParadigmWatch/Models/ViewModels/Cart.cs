using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParadigmWatch.Models.ViewModels
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Watch product, int quantity)
        {
            // check to see if the product is already in the cart
            CartLine item = lineCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();

            // add product or update quantity
            if (item == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });

            }

            else
            {
                item.Quantity += quantity;
            }
        }

        public virtual void RemoveLine(Watch product) =>
            lineCollection.RemoveAll(i => i.Product.Id == product.Id);

        // Linq syntax, return the total price for all products in the cart
        public decimal ComputeTotalValue() =>
            lineCollection.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();

        public List<CartLine> Lines => lineCollection;
    }

    public class CartLine
    {
        public Watch Product { get; set; }
        public int Quantity { get; set; }
    }
}

