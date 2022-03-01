using Newtonsoft.Json;
using OutfitCreator.Domain.IRepository;
using OutfitCreator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Infra.Data.Repository
{
    public class ProductRepository : IProductRepository
    {
        private static readonly HttpClient httpClient;
        static ProductRepository()
        {
            httpClient = new HttpClient();
        }

        public async Task<Product> GetProductById(string Id)
        {
            string url = "https://api.newyorker.de/csp/products/public/product/"+ Id +"?country=de";
            // Add an Accept header for JSON format.
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // data response.
            var response = await httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataString = await response.Content.ReadAsStringAsync();
                var product = JsonConvert.DeserializeObject<Product>(dataString);
                return product;
            }
            return null;
        }

        public async Task<IEnumerable<Product>> GetProducts(string Gender, string Webcategories)
        {
            string url = "https://api.newyorker.de/csp/products/public/query?filters[country]=de&filters[gender]=" + Gender + "&filters[web_category]="+ Webcategories;
            // Add an Accept header for JSON format.
            httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

            // List data response.
            var response =  await httpClient.GetAsync(url);  
            if (response.IsSuccessStatusCode)
            {
                // Parse the response body.
                var dataString = await response.Content.ReadAsStringAsync();
                var responseModel = JsonConvert.DeserializeObject<ResponseModel>(dataString);
                return responseModel.Items;
            }
            return null;
        }
    }
}
