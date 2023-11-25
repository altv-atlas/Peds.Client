using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Net.Data;

namespace AltV.Atlas.Peds.Client.Delegates;

/// <summary>
/// PedSpawnDelegate
/// </summary>
public delegate void PedSpawnDelegate( Position position, IPedTask? currentTask );