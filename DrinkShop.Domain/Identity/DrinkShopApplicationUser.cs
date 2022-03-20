using DrinkShop.Domain.DomainModels;
using Microsoft.AspNetCore.Identity;

namespace DrinkShop.Domain.Identity
{
    public class DrinkShopApplicationUser : IdentityUser
    {
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ShoppingCart UserCart { get; set; }
    }
}
