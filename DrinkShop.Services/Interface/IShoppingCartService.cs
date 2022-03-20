using DrinkShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Services.Interface
{
    public interface IShoppingCartService
    {
        ShoppingCartDTO getShoppingCartInfo(string userId);
        bool deleteProductFromShoppingCart(string userId, Guid id);
        bool orderNow(string userId);
    }
}
