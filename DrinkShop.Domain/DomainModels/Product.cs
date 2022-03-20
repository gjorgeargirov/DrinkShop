using System;
using System.Collections.Generic;

namespace DrinkShop.Domain.DomainModels
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public string ProductImage { get; set; }
        public string ProductDescription { get; set; }
        public int Price { get; set; }
        public virtual ICollection<ProductInShoppingCart> ProductInShoppingCarts { get; set; }
        public virtual ICollection<ProductInOrder> Orders { get; set; }
    }
}
