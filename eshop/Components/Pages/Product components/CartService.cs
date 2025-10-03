using System;
using System.Collections.Generic;
using eshop.Data.Entities;

namespace eshop.Components.Pages.Product_components
{
    public interface ICartService
    {
        void AddToCart(Product product, int quantity = 1);
        IReadOnlyList<(Product product, int quantity)> GetCartItems();
        void RemoveFromCart(Product product);
        void ClearCart();
    }

    public class CartService : ICartService
    {
        private readonly List<(Product product, int quantity)> _items = new();

        public void AddToCart(Product product, int quantity = 1)
        {
            var index = _items.FindIndex(x => x.product.Id == product.Id);
            if (index >= 0)
                _items[index] = (product, _items[index].quantity + quantity);
            else
                _items.Add((product, quantity));
        }

        public IReadOnlyList<(Product product, int quantity)> GetCartItems() => _items.AsReadOnly();

        public void RemoveFromCart(Product product)
        {
            _items.RemoveAll(x => x.product.Id == product.Id);
        }

        public void ClearCart() => _items.Clear();
    }
}
