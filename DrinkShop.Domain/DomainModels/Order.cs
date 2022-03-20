
using DrinkShop.Domain.Identity;
using System;
using System.Collections.Generic;

namespace DrinkShop.Domain.DomainModels
{
    public class Order : BaseEntity
    {
        public string UserId { get; set; }
        public DrinkShopApplicationUser User { get; set; }

        public virtual ICollection<ProductInOrder> Products { get; set; }
    }
}
