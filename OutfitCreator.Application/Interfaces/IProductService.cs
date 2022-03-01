using OutfitCreator.Application.ViewModels;
using OutfitCreator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Application.Interfaces
{
    public interface IProductService
    {
        public Task<Outfit> GetRandomOutfit(string Gender);
        public Task<Product> GetProductById(string Id);
    }
}
