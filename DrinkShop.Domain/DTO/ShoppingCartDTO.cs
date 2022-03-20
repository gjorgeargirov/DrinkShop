
using DrinkShop.Domain.DomainModels;
using System.Collections.Generic;

namespace DrinkShop.Domain.DTO
{
    public class ShoppingCartDTO
    {
        public List<ProductInShoppingCart> ProductInShoppingCarts { get; set; }

        public double TotalPrice { get; set; }
    }
}
