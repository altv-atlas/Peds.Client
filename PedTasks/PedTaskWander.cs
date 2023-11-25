using System.Numerics;
using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Peds.Shared.PedTasks;
using AltV.Net.Client;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Peds.Client.PedTasks;

/// <summary>
/// A task to make the ped wander around in an area
/// </summary>
public class PedTaskWander : PedTaskWanderBase
{
    /// <summary>
    /// Creates a new wander task
    /// </summary>
    /// <param name="position">The position to wander around</param>
    /// <param name="radius">Radius from position the ped can wander in</param>
    /// <param name="minLength">Minimum length of a walk</param>
    /// <param name="timeBetweenWalks">Time the ped waits between walks</param>
    public PedTaskWander( Vector3 position, uint radius, uint minLength, uint timeBetweenWalks ) : base( position, radius, minLength, timeBetweenWalks )
    {
    }    
    
    /// <summary>
    /// Triggered when the ped starts the task. Unused on server-side
    /// </summary>
    /// <param name="sharedPed">The ped that starts the task</param>
    public override void OnStart( ISharedPed sharedPed )
    {
        Alt.Log( "OnStart PedTaskWander 1" );
        if( sharedPed is not IAtlasClientPed ped )
            return;
        
        Alt.Log( "OnStart PedTaskWander 2" );
        Alt.Natives.TaskWanderInArea( ped.ScriptId, Position.X, Position.Y, Position.Z, Radius, MinLength, TimeBetweenWalks );
    }
}