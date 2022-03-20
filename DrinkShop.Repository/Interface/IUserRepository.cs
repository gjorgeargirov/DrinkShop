using DrinkShop.Domain.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Repository.Interface
{
    public interface IUserRepository
    {
        IEnumerable<DrinkShopApplicationUser> GetAll();
        DrinkShopApplicationUser Get(string id);
        void Insert(DrinkShopApplicationUser entity);
        void Update(DrinkShopApplicationUser entity);
        void Delete(DrinkShopApplicationUser entity);
    }
}
