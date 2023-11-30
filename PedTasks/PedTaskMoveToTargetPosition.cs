using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Peds.Shared.PedTasks;
using AltV.Net;
using AltV.Net.Client;
using AltV.Net.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Peds.Client.PedTasks;

/// <summary>
/// A task to make the ped move(walk) to a given position
/// </summary>
public class PedTaskMoveToTargetPosition : PedTaskMoveToTargetPositionBase
{

    /// <summary>
    /// Ad task to make the ped move(walk) to a given position
    /// </summary>
    /// <param name="targetPosition">The position to move to</param>
    public PedTaskMoveToTargetPosition( Position targetPosition )
    {
        TargetPosition = targetPosition;
    }
    
    /// <summary>
    /// Triggered when the ped starts the task. Unused on server-side
    /// </summary>
    /// <param name="sharedPed">The ped that starts the task</param>
    public override void OnStart( ISharedPed sharedPed )
    {
        if( sharedPed is not IAtlasClientPed ped )
            return;
        
    }
}