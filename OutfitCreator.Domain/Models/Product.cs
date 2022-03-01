using System;
using System.Collections.Generic;
using System.Text;

namespace OutfitCreator.Domain.Models
{
    public class Product
    {
        public string Id { get; set; }
        public string Country { get; set; }
        public string Web_category { get; set; }
        public string Brand { get; set; }
        public List<Variant> Variants { get; set; }

    }
}
