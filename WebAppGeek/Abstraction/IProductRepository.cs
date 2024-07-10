using Microsoft.AspNetCore.Mvc;
using WebAppGeek.Dto;
using WebAppGeek.Models;

namespace WebAppGeek.Abstraction
{
    public interface IProductRepository
    {
        IEnumerable<ProductDto> GetAllProducts();
        int AddProduct(ProductDto productDto);
        void DeleteProduct(int id);
        string GetProductsCSV();
    }
}