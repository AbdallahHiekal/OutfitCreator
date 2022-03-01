using OutfitCreator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutfitCreator.Application.ViewModels
{
    public class Outfit
    {
        public Product Accessory { get; set; }
        public Product Outerwear { get; set; }
        public Product Underwear { get; set; }
        public string Gender { get; set; }
    }
}
