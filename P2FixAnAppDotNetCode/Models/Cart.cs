using System;
using System.Collections.Generic;
using System.Linq;

namespace P2FixAnAppDotNetCode.Models
{
    /// <summary>
    /// The Cart class
    /// </summary>
    public class Cart : ICart
    {
        private List<CartLine> _cartLineList { get; }

        public Cart()
        {
            this._cartLineList = new List<CartLine>();
        }

        /// <summary>
        /// Read-only property for display only
        /// </summary>
        public IEnumerable<CartLine> Lines => this._cartLineList;

        /// <summary>
        /// Adds a product in the cart or increment its quantity in the cart if already added
        /// </summary>//
        public void AddItem(Product product, int quantity)
        {
            CartLine line = this._cartLineList.FirstOrDefault(l => l.Product.Id == product.Id);
            if (line != null)
            {
                line.Quantity = Math.Min(product.Stock, line.Quantity + quantity);
            }
            else
            {
                int newLineId = this._cartLineList.Count() == 0 ? 1 : this._cartLineList.Select(l => l.OrderLineId).Max() + 1;
                this._cartLineList.Add(new CartLine { OrderLineId = newLineId, Product = product, Quantity = Math.Min(product.Stock, quantity) });
            }
        }

        /// <summary>
        /// Removes a product form the cart
        /// </summary>
        public void RemoveLine(Product product) => this._cartLineList.RemoveAll(l => l.Product.Id == product.Id);

        /// <summary>
        /// Get total value of a cart
        /// </summary>
        public double GetTotalValue()
        {
            return this._cartLineList.Sum(l => l.Quantity * l.Product.Price);
        }

        /// <summary>
        /// Get average value of a cart
        /// </summary>
        public double GetAverageValue()
        {
            double avg = 0d;
            if (this._cartLineList.Count() > 0)
            {
                avg = this.GetTotalValue() / this._cartLineList.Sum(l => l.Quantity);
            }

            return avg;
        }

        /// <summary>
        /// Looks after a given product in the cart and returns if it finds it
        /// </summary>
        public Product FindProductInCartLines(int productId)
        {
            // TODO implement the method
            return null;
        }

        /// <summary>
        /// Get a specific cartline by its index
        /// </summary>
        public CartLine GetCartLineByIndex(int index)
        {
            return Lines.ToArray()[index];
        }

        /// <summary>
        /// Clears a the cart of all added products
        /// </summary>
        public void Clear()
        {
            List<CartLine> cartLines = this._cartLineList;
            cartLines.Clear();
        }
    }

    public class CartLine
    {
        public int OrderLineId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
