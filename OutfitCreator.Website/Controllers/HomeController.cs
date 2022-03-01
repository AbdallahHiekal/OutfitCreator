using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OutfitCreator.Application.Interfaces;
using OutfitCreator.Application.ViewModels;
using OutfitCreator.Website.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace OutfitCreator.Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService _productService;

        public HomeController(ILogger<HomeController> logger, IProductService productService)
        {
            _logger = logger;
            _productService = productService;
        }

        public async Task<IActionResult> Index(string Gender = "FEMALE")
        {
            Outfit randomOutfit = await _productService.GetRandomOutfit(Gender);
            randomOutfit.Gender = Gender;

            return View(randomOutfit);
        }

        public async Task <IActionResult> ProductDetails(string Id)
        {
            var product = await _productService.GetProductById(Id);
            if(product == null) 
            {
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
