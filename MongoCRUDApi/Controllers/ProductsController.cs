using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoCRUDApi.Models;
using MongoDB.Driver;

namespace MongoCRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductDbContext context = null;
        List<Product> products = new List<Product>();
        public ProductsController()
        {
            context = new ProductDbContext();
        }

        [HttpGet]
        public List<Product> GetAllProducts()
        {
            products = context.Products.Find(products => true).ToList();
            return products;

        }
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            Product product = context.Products.Find(p => p.ProductId == id).FirstOrDefault();
            return product;

        }
        [HttpPost]
        public Product AddNewProduct(Product product)
        {
            context.Products.InsertOne(product);
            return product;
        }
        [HttpPut]
        public async Task<Product> Update(int id,Product product)
        {
           await context.Products.ReplaceOneAsync(x => x.ProductId==id, product);
            return product;
        }
        [HttpDelete]
        public async void Delete(int id)
        {
            await context.Products.DeleteOneAsync(x => x.ProductId == id);
            
        }
    }
}
