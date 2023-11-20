using System.Numerics;
using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Peds.Shared.PedTasks;
using AltV.Net.Client;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Peds.Client.PedTasks;

public class PedTaskWander : PedTaskWanderBase, IPedTask
{
    public PedTaskWander( Vector3 position, uint radius, uint minLength, uint timeBetweenWalks ) : base( position, radius, minLength, timeBetweenWalks )
    {
    }
    public void OnStart( ISharedPed sharedPed )
    {
        Alt.Log( "OnStart PedTaskWander 1" );
        if( sharedPed is not IAtlasClientPed ped )
            return;
        
        Alt.Log( "OnStart PedTaskWander 2" );
        Alt.Natives.TaskWanderInArea( ped.ScriptId, Position.X, Position.Y, Position.Z, Radius, MinLength, TimeBetweenWalks );
    }

    public void OnStop( )
    {
        throw new NotImplementedException( );
    }
}