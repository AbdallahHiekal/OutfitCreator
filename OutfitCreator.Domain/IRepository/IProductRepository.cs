using OutfitCreator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Domain.IRepository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts(string Gender, string Webcategories);
        public Task<Product> GetProductById(string Id);
    }
}
