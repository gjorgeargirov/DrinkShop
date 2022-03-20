using DrinkShop.Domain.Identity;
using System;
using System.Collections.Generic;

namespace DrinkShop.Domain.DomainModels
{
    public class ShoppingCart : BaseEntity
    {
        public string OwnerId { get; set; }
        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        public DrinkShopApplicationUser Owner { get; set; }
    }
}
