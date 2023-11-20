﻿using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Peds.Shared.PedTasks;
using AltV.Net.Shared.Elements.Entities;

namespace AltV.Atlas.Peds.Client.PedTasks;

public class PedTaskIdle : PedTaskIdleBase, IPedTask
{
    public void OnStart( ISharedPed ped )
    {
        throw new NotImplementedException( );
    }

    public void OnStop( )
    {
        throw new NotImplementedException( );
    }
}