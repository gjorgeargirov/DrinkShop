using DrinkShop.Domain.DomainModels;
using DrinkShop.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrinkShop.Services.Interface
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Product p);
        void UpdateExistingProduct(Product p);
        AddToShoppingCartDto GetShoppingCartInfo(Guid? id);
        void DeleteProduct(Guid? id);
        bool AddToShoppingCart(AddToShoppingCartDto item, string userID);
    }
}
