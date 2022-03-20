using DrinkShop.Domain.Identity;
using DrinkShop.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrinkShop.Repository.Implementatiton
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext context;
        private DbSet<DrinkShopApplicationUser> entities;
        string errorMessage = string.Empty;

        public UserRepository(ApplicationDbContext context)
        {
            this.context = context;
            entities = context.Set<DrinkShopApplicationUser>();
        }

        public IEnumerable<DrinkShopApplicationUser> GetAll()
        {
            return entities.AsEnumerable();
        }

        public DrinkShopApplicationUser Get(string id)
        {
            return entities
                .Include(x => x.UserCart)
                .Include("UserCart.ProductInShoppingCarts")
                .Include("UserCart.ProductInShoppingCarts.Product")
                .SingleOrDefault(x => x.Id == id);
        }

        public void Insert(DrinkShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Add(entity);
            context.SaveChanges();
        }

        public void Update(DrinkShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Update(entity);
            context.SaveChanges();
        }
        public void Delete(DrinkShopApplicationUser entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            entities.Remove(entity);
            context.SaveChanges();
        }
    }
}
