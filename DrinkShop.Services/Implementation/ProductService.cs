using DrinkShop.Domain.DomainModels;
using DrinkShop.Domain.DTO;
using DrinkShop.Repository.Interface;
using DrinkShop.Services.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DrinkShop.Services.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<ProductInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        private readonly ILogger<ProductService> _logger;
        public ProductService(IRepository<Product> productRepository, ILogger<ProductService> logger, IUserRepository userRepository, IRepository<ProductInShoppingCart> productInShoppingCartRepository)
        {
            _productRepository = productRepository;
            _userRepository = userRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _logger = logger;
        }
        public bool AddToShoppingCart(AddToShoppingCartDto item, string userID)
        {
            var user = this._userRepository.Get(userID);
            var userShoppingCart = user.UserCart;

            if (item.ProductId != null && userShoppingCart != null)
            {
                var product = this.GetDetailsForProduct(item.ProductId);
                if (product != null)
                {
                    ProductInShoppingCart itemToAdd = new ProductInShoppingCart
                    {
                        ProductId = userShoppingCart.Id,
                        Product = product,
                        ShoppingCartId = product.Id,
                        ShoppingCart = userShoppingCart,
                        Quantity = item.Quantity
                    };
                    this._productInShoppingCartRepository.Insert(itemToAdd);
                    _logger.LogInformation("Product was successfuly added into Shopping Cart");
                    return true;
                }
                return false;
            }
            _logger.LogInformation("Someting was wrong. ProductID or UserShoppingCart");
            return false;
        }

        public void CreateNewProduct(Product p)
        {
            this._productRepository.Insert(p);
        }

        public void DeleteProduct(Guid? id)
        {
            var product = this.GetDetailsForProduct(id);
            this._productRepository.Delete(product);
        }

        public List<Product> GetAllProducts()
        {
            return this._productRepository.GetAll().ToList();
        }

        public Product GetDetailsForProduct(Guid? id)
        {
            return this._productRepository.Get(id);
        }

        public AddToShoppingCartDto GetShoppingCartInfo(Guid? id)
        {
            var product = this.GetDetailsForProduct(id);

            AddToShoppingCartDto model = new AddToShoppingCartDto
            {
                SelectedProduct = product,
                ProductId = product.Id,
                Quantity = 1
            };

            return model;
        }

        public void UpdateExistingProduct(Product p)
        {
            this._productRepository.Update(p);
        }
    }
}
