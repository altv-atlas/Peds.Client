using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Peds.Shared.PedTasks;
using AltV.Net;
using AltV.Net.Client;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Peds.Client.PedTasks;

/// <summary>
/// Task to make the ped follow a player
/// </summary>
public class PedTaskFollowPlayer : PedTaskFollowPlayerBase
{
    /// <summary>
    /// Task to make the ped follow a player
    /// </summary>
    /// <param name="targetId">The remote ID of the player</param>
    public PedTaskFollowPlayer( uint targetId ) : base( targetId )
    {
    }
    
    /// <summary>
    /// Triggered when the ped starts the task. Unused on server-side
    /// </summary>
    /// <param name="sharedPed">The ped that starts the task</param>
    public override void OnStart( ISharedPed sharedPed )
    {
        if( sharedPed is not IAtlasClientPed ped )
            return;
        
        Alt.Log( "OnStart PedTaskFollowPlayer" );

        var player = Alt.GetAllPlayers( ).FirstOrDefault( p => p.RemoteId == TargetId );

        if( player is null )
            return;
        
        Alt.Natives.TaskFollowToOffsetOfEntity( ped.ScriptId, player, 1.5f, 1.5f, 0, 10, -1, 5, true );

    }
}