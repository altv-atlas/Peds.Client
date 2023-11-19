using AltV.Atlas.Peds.Client.Base;
using AltV.Atlas.Peds.Client.Factories;
using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Net.Client;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Peds.Client;

public static class PedModule
{
    /// <summary>
    /// Registers the ped module and it's classes/interfaces
    /// </summary>
    /// <param name="serviceCollection">A service collection</param>
    /// <returns>The service collection</returns>
    public static IServiceCollection RegisterPedModule( this IServiceCollection serviceCollection )
    {
        Alt.Log( "RegisterPedModule" );
        serviceCollection.AddTransient<IAtlasClientPed, AtlasPed>( );
        serviceCollection.AddTransient<IPed, Ped>( );

        serviceCollection.AddTransient<IEntityFactory<IPed>, AltPedFactory>( );
        
        return serviceCollection;
    }
}