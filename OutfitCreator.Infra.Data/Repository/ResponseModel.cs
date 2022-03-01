using OutfitCreator.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OutfitCreator.Infra.Data.Repository
{
    public class ResponseModel
    {
        public int TotalCount { get; set; }
        public IEnumerable<Product> Items { get; set; }
    }
}
