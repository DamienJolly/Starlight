﻿using Microsoft.Extensions.DependencyInjection;
using Starlight.API;
using Starlight.API.Game.Catalog;

namespace Starlight.Game.Catalog
{
    /// <summary>
    /// The catalog service initializes the required services.
    /// </summary>
    public class Catalog : IService
    {
        public void RegisterServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<CatalogDao>();
            serviceCollection.AddSingleton<CatalogRepository>();
            serviceCollection.AddSingleton<ICatalogController, CatalogController>();
        }
    }
}