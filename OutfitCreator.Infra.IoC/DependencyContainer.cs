using Microsoft.Extensions.DependencyInjection;
using OutfitCreator.Application.Interfaces;
using OutfitCreator.Application.Services;
using OutfitCreator.Domain.IRepository;
using OutfitCreator.Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutfitCreator.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            
            #region Product
            //Application Layer
            services.AddScoped<IProductService, ProductService>();
            //Data Layer
            services.AddScoped<IProductRepository, ProductRepository>();

            #endregion
            
        }
    }
}
