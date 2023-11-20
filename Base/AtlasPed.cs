using System.Numerics;
using AltV.Atlas.Peds.Client.Delegates;
using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Shared.Converters;
using AltV.Net.Client;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;

namespace AltV.Atlas.Peds.Client.Base;

public class AtlasPed : Ped, IAtlasClientPed
{
    public IPedTask? CurrentTask
    {
        get
        {
            GetStreamSyncedMetaData( "CurrentTask", out string? taskJson );
            Alt.Log( $"current task: { taskJson }" );
            return TypeConverter.FromJson<IPedTask>( taskJson, "Id" );
        }
    }

    public event PedSpawnDelegate? OnSpawn;
    
    public AtlasPed( ICore core, IntPtr pedNativePointer, uint id ) : base( core, pedNativePointer, id )
    {
        Alt.Log( "PED SPAWN" );
        
        Alt.OnGameEntityCreate += OnGameEntityCreate;
        Alt.OnGameEntityDestroy += OnGameEntityDestroy;
        Alt.OnNetOwnerChange += OnNetOwnerChange;
        Alt.OnStreamSyncedMetaChange += OnStreamSyncedMetaChange;
    }

    protected virtual void OnStreamSyncedMetaChange( IBaseObject target, string key, object value, object oldValue )
    {
        if( target is not IAtlasClientPed atlasPed || atlasPed.Id != Id )
            return;

        Alt.Log( $"OnStreamSyncedMetaChange"  );
        switch( key )
        {
            case "CurrentTask":
            {
                var oldTask = TypeConverter.FromJson<IPedTask>( (string) oldValue, "Id" );
                var newTask = TypeConverter.FromJson<IPedTask>( (string) value, "Id" );

                oldTask?.OnStop( );
                newTask?.OnStart( this );
                break;
            }
        }
    }

    protected virtual void OnGameEntityCreate( IEntity entity )
    {
        if( entity is not IAtlasClientPed atlasPed || atlasPed.Id != Id )
            return;
        
        Alt.Log( $"OnGameEntityCreate for ped {Id}" );
        if( NetworkOwner != Alt.LocalPlayer )
            return;
        
        OnPedSpawn( );
    }
    
    protected virtual void OnGameEntityDestroy( IEntity entity )
    {
        if( entity is not IAtlasClientPed atlasPed || atlasPed.Id != Id )
            return;
        
        Alt.Log( $"OnGameEntityDestroy for ped {Id}" );
        if( NetworkOwner != Alt.LocalPlayer )
            return;

        Alt.OnGameEntityCreate -= OnGameEntityCreate;
        Alt.OnGameEntityDestroy -= OnGameEntityDestroy;
        Alt.OnNetOwnerChange -= OnNetOwnerChange;
        Alt.OnStreamSyncedMetaChange -= OnStreamSyncedMetaChange;
        CurrentTask?.OnStop(  );
    }

    protected virtual void OnNetOwnerChange( IEntity entity, IPlayer? newOwner, IPlayer? oldOwner )
    {
        if( entity is not IAtlasClientPed atlasPed || atlasPed.Id != Id )
            return;
        
        Alt.Log( $"OnNetOwnerChange for ped {Id}" );
        if( NetworkOwner != Alt.LocalPlayer )
            return;
        
        OnPedSpawn(  );
    }
    
    protected virtual void OnPedSpawn( )
    {
        Alt.Log( "OnPedSpawn" );
        SetDefaults(  );

        CurrentTask?.OnStart( this );
        
        OnSpawn?.Invoke( Position, CurrentTask );
    }
    
    protected virtual void SetDefaults( )
    {
        Alt.Log( $"SetDefaults" );
        Alt.Natives.SetEntityAsMissionEntity( ScriptId, true, false );
        Alt.Natives.SetBlockingOfNonTemporaryEvents( ScriptId, true );
        Alt.Natives.TaskSetBlockingOfNonTemporaryEvents( ScriptId, true );
        Alt.Natives.SetPedSuffersCriticalHits( ScriptId, false );
        Alt.Natives.SetPedDropsWeaponsWhenDead( ScriptId, false );
        Alt.Natives.SetPedDiesInstantlyInWater( ScriptId, false );
        Alt.Natives.SetPedCanRagdoll( ScriptId, false );
        Alt.Natives.SetPedDiesWhenInjured( ScriptId, false );
        Alt.Natives.SetPedFleeAttributes( ScriptId, 0, false );
        Alt.Natives.SetPedConfigFlag( ScriptId, 32, false );
        Alt.Natives.SetPedConfigFlag( ScriptId, 2, true );
        Alt.Natives.SetPedConfigFlag( ScriptId, 281, true );
        Alt.Natives.SetPedConfigFlag( ScriptId, 188, true );
        Alt.Natives.SetPedGetOutUpsideDownVehicle( ScriptId, false );
        Alt.Natives.SetPedCanEvasiveDive( ScriptId, false );
        Alt.Natives.SetPedNeverLeavesGroup( ScriptId, true );
        Alt.Natives.SetCanAttackFriendly( ScriptId, false, false );
        Alt.Natives.SetPedCombatAbility( ScriptId, 100 );
        Alt.Natives.SetPedCombatMovement( ScriptId, 3 );
        Alt.Natives.SetPedCombatAttributes( ScriptId, 0, false );
        Alt.Natives.SetPedCombatAttributes( ScriptId, 1, false );
        Alt.Natives.SetPedCombatAttributes( ScriptId, 2, false );
        Alt.Natives.SetPedCombatAttributes( ScriptId, 3, false );
        Alt.Natives.SetPedCombatAttributes( ScriptId, 20, false );
        Alt.Natives.SetPedCombatAttributes( ScriptId, 292, true );
        
        Alt.Natives.SetPedCombatRange( ScriptId, 2 );
        Alt.Natives.SetPedKeepTask( ScriptId, true );
        Alt.Natives.SetPedSteersAroundObjects( ScriptId, true );
        Alt.Natives.SetPedSteersAroundVehicles( ScriptId, true );
        Alt.Natives.SetPedSteersAroundDeadBodies( ScriptId, true );
        Alt.Natives.SetEntityProofs( ScriptId, false, false, false, false, false, false, false, true );
        
        Alt.Natives.SetPedArmour( ScriptId, 0 );
        Alt.Natives.SetPedAlertness( ScriptId, 3 );
        Alt.Natives.SetPedEnableWeaponBlocking( ScriptId, true );
    }
}