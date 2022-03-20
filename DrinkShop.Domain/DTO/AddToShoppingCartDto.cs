
using DrinkShop.Domain.DomainModels;
using System;

namespace DrinkShop.Domain.DTO
{
    public class AddToShoppingCartDto
    {
        public Product SelectedProduct { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
