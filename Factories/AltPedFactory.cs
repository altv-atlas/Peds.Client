using AltV.Atlas.Peds.Client.Base;
using AltV.Net.Client;
using AltV.Net.Client.Elements.Factories;
using AltV.Net.Client.Elements.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace AltV.Atlas.Peds.Client.Factories;

/// <summary>
/// Entity factory for atlas peds
/// </summary>
public class AltPedFactory : IEntityFactory<IPed>
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Creates a new instance of ped factory
    /// </summary>
    /// <param name="serviceProvider">service provider that contains the AtlasPed class</param>
    public AltPedFactory( IServiceProvider serviceProvider )
    {
        _serviceProvider = serviceProvider;
    }
    
    /// <summary>
    /// Create a new atlas ped
    /// </summary>
    /// <param name="core">AltV Core</param>
    /// <param name="entityPointer">Entity ptr</param>
    /// <param name="id">ID of the ped</param>
    /// <returns>A new atlas ped</returns>
    public IPed Create( ICore core, IntPtr entityPointer, uint id )
    {
        Alt.Log( "AltPedFactory Create" );
        return ActivatorUtilities.CreateInstance<AtlasPed>( _serviceProvider, core, entityPointer, id );
    }
}