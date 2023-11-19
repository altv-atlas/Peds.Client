using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Peds.Shared.PedTasks;
using AltV.Net;
using AltV.Net.Client;
using AltV.Net.Data;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Peds.Client.PedTasks;

public class PedTaskMoveToTargetPosition : PedTaskMoveToTargetPositionBase, IPedTask
{

    public PedTaskMoveToTargetPosition( Position targetPosition )
    {
        TargetPosition = targetPosition;
    }
    
    
    public void Execute( ISharedPed sharedPed )
    {
        if( sharedPed is not IAtlasClientPed ped )
            return;
        
        Alt.Log( "Execute PedTaskMoveToTargetPosition" );


        throw new NotImplementedException( );
    }
}