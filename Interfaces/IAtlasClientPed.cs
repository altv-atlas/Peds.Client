using System.Numerics;
using AltV.Atlas.Peds.Client.Delegates;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;

namespace AltV.Atlas.Peds.Client.Interfaces;

public interface IAtlasClientPed : IAtlasPed, IPed
{
    event PedSpawnDelegate? OnSpawn;
}