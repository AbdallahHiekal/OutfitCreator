using Microsoft.Extensions.Configuration;
using OutfitCreator.Application.Interfaces;
using OutfitCreator.Application.ViewModels;
using OutfitCreator.Domain.IRepository;
using OutfitCreator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IConfiguration _config;
        public ProductService(IProductRepository productRepository, IConfiguration config)
        {
            _productRepository = productRepository;
            _config = config;
        }
        public async Task<Outfit> GetRandomOutfit(string Gender)
        {
            string AccessoiresCat = null;
            string OuterwearCat = null;
            string UnderwearCat = null;

            if (Gender == "FEMALE") {
                AccessoiresCat = _config["WomenWebCategories:Accessoires"];
                OuterwearCat = _config["WomenWebCategories:Outerwear"];
                UnderwearCat = _config["WomenWebCategories:Underwear"];
            }
            else {
                AccessoiresCat = _config["MenWebCategories:Accessoires"];
                OuterwearCat = _config["MenWebCategories:Outerwear"];
                UnderwearCat = _config["MenWebCategories:Underwear"];
            }

            // get Produts of type Accessoires, OuterwearCat, and UnderwearCat
            var Accessoires = _productRepository.GetProducts(Gender, AccessoiresCat);
            var Outerwears = _productRepository.GetProducts(Gender, OuterwearCat);
            var Underwears = _productRepository.GetProducts(Gender, UnderwearCat);

            Task.WaitAll(Accessoires, Outerwears, Underwears);

            Outfit RandomOutfit = new Outfit()
            {
                Accessory = GetRandomProduct(await Accessoires),
                Outerwear = GetRandomProduct(await Outerwears),
                Underwear = GetRandomProduct(await Underwears),
                Gender = Gender
            };
            if(RandomOutfit.Accessory ==  null || RandomOutfit.Outerwear == null || RandomOutfit.Underwear == null) 
            {
                return null;
            }
            return RandomOutfit;
        }
        public async Task<Product> GetProductById(string Id)
        {
            return await _productRepository.GetProductById(Id);
        }
        // get random product from a list of products
        private Product GetRandomProduct(IEnumerable<Product> Products) 
        {
            var produectList = Products.ToList();
            if (produectList.Count == 0) return null;
            int randomNumber = GetRandomNumberInRange(produectList.Count);
            return produectList[randomNumber];
        }
        // get random number from 0 to n-1
        private int GetRandomNumberInRange(int Number) 
        {
            Random rand = new Random();
            int number = rand.Next(0, Number);
            return number;
        }
    }
}
