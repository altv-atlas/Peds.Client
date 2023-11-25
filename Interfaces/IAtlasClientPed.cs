using System.Numerics;
using AltV.Atlas.Peds.Client.Delegates;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;

namespace AltV.Atlas.Peds.Client.Interfaces;

/// <summary>
/// Client-side version of atlas ped
/// </summary>
public interface IAtlasClientPed : IAtlasPed, IPed
{
    /// <summary>
    /// Returns true if the ped is in a vehicle
    /// </summary>
    bool IsInVehicle { get; }
    
    /// <summary>
    /// Triggered when the ped spawns
    /// </summary>
    event PedSpawnDelegate? OnSpawn;
}