using System;
using System.Collections.Generic;
using System.Text;

namespace OutfitCreator.Domain.Models
{
    public class Variant
    {
        public string Id { get; set; }
        public string Current_price { get; set; }
        public string Color_name { get; set; }
        public bool Coming_soon { get; set; }
        public List<Image> Images { get; set; }
    }
}
