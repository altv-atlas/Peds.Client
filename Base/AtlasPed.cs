﻿using System.Text.Json;
using AltV.Atlas.Peds.Client.Delegates;
using AltV.Atlas.Peds.Client.Enums;
using AltV.Atlas.Peds.Client.Interfaces;
using AltV.Atlas.Peds.Shared;
using AltV.Atlas.Peds.Shared.Interfaces;
using AltV.Atlas.Shared.Converters;
using AltV.Net.Client;
using AltV.Net.Client.Elements.Entities;
using AltV.Net.Client.Elements.Interfaces;
using AltV.Net.Data;

namespace AltV.Atlas.Peds.Client.Base;

/// <summary>
/// Client-side atlas ped
/// </summary>
public class AtlasPed : Ped, IAtlasClientPed
{
    /// <summary>
    /// The task the ped is currently doing (eg wander, follow player, etc)
    /// </summary>
    /// 
    private readonly JsonTypeConverter<IPedTask> _pedTaskJsonConverter = new();
    
    /// <summary>
    /// The task this ped is performing currently
    /// </summary>
    public IPedTask? CurrentTask
    {
        get
        {
            GetStreamSyncedMetaData( PedConstants.CurrentTaskMetaKey, out string? taskJson );

            if( taskJson is null )
                return default;
            
            return JsonSerializer.Deserialize<IPedTask>( taskJson, JsonOptions.WithConverters(_pedTaskJsonConverter));
        }
    }
    
    /// <summary>
    /// Returns true if the ped is in a vehicle
    /// </summary>
    public bool IsInVehicle => Alt.Natives.IsPedInAnyVehicle( ScriptId, false );
    
    /// <summary>
    /// Triggered when the ped spawns
    /// </summary>
    public event PedSpawnDelegate? OnSpawn;
    
    /// <summary>
    /// Client-side atlas ped
    /// </summary>
    /// <param name="core">Alt core</param>
    /// <param name="pedNativePointer">Native pointer</param>
    /// <param name="id">ID of the ped</param>
    public AtlasPed( ICore core, IntPtr pedNativePointer, uint id ) : base( core, pedNativePointer, id )
    {
        Alt.OnGameEntityCreate += OnGameEntityCreate;
        Alt.OnGameEntityDestroy += OnGameEntityDestroy;
        Alt.OnNetOwnerChange += OnNetOwnerChange;
        Alt.OnStreamSyncedMetaChange += OnStreamSyncedMetaChange;
    }

    /// <summary>
    /// Triggered when streamsyncedmeta data has changed
    /// </summary>
    /// <param name="target">The target that had it's meta data changed</param>
    /// <param name="key">The key of the value that was changed</param>
    /// <param name="value">The value that changed</param>
    /// <param name="oldValue">The value prior to change</param>
    protected virtual void OnStreamSyncedMetaChange( IBaseObject target, string key, object value, object oldValue )
    {
        if( target is not IAtlasClientPed atlasPed || atlasPed.Id != Id || NetworkOwner != Alt.LocalPlayer )
            return;

        switch( key )
        {
            case PedConstants.CurrentTaskMetaKey:
            {
                if( oldValue is string oldValueString )
                {
                    var oldTask = JsonSerializer.Deserialize<IPedTask>(oldValueString, JsonOptions.WithConverters(_pedTaskJsonConverter));
                    oldTask?.OnStop( this );
                }

                if( value is string valueString )
                {
                    var newTask = JsonSerializer.Deserialize<IPedTask>(valueString, JsonOptions.WithConverters(_pedTaskJsonConverter));
                    newTask?.OnStart( this );
                }

                break;
            }
        }
    }

    /// <summary>
    /// Triggered when a game entity is created
    /// </summary>
    /// <param name="entity">The entity</param>
    protected virtual void OnGameEntityCreate( IEntity entity )
    {
        if( entity is not IAtlasClientPed atlasPed || atlasPed.Id != Id )
            return;
        
        if( NetworkOwner != Alt.LocalPlayer )
            return;
        
        OnPedSpawn( );
    }
    
    /// <summary>
    /// Triggered when a game entity is destroyed
    /// </summary>
    /// <param name="entity">The entity</param>
    protected virtual void OnGameEntityDestroy( IEntity entity )
    {
        if( entity is not IAtlasClientPed atlasPed || atlasPed.Id != Id )
            return;
        
        if( NetworkOwner != Alt.LocalPlayer )
            return;

        Alt.OnGameEntityCreate -= OnGameEntityCreate;
        Alt.OnGameEntityDestroy -= OnGameEntityDestroy;
        Alt.OnNetOwnerChange -= OnNetOwnerChange;
        Alt.OnStreamSyncedMetaChange -= OnStreamSyncedMetaChange;
        CurrentTask?.OnStop( this );
    }

    /// <summary>
    /// Triggered when netowner changes
    /// </summary>
    /// <param name="entity">The entity</param>
    /// <param name="newOwner">New net owner</param>
    /// <param name="oldOwner">Netowner prior to change</param>
    protected virtual void OnNetOwnerChange( IEntity entity, IPlayer? newOwner, IPlayer? oldOwner )
    {
        if( entity is not IAtlasClientPed atlasPed || atlasPed.Id != Id )
            return;
        
        if( NetworkOwner != Alt.LocalPlayer )
            return;
        
        OnPedSpawn(  );
    }
    
    /// <summary>
    /// Triggered when the ped spawns
    /// </summary>
    protected virtual void OnPedSpawn( )
    {
        SetDefaults(  );

        CurrentTask?.OnStart( this );
        
        OnSpawn?.Invoke( Position, CurrentTask );
    }
    
    /// <summary>
    /// Set default natives for this ped (make it dumb etc)
    /// </summary>
    protected virtual void SetDefaults( )
    {
        Alt.Natives.SetEntityAsMissionEntity( ScriptId, true, false );
        Alt.Natives.SetBlockingOfNonTemporaryEvents( ScriptId, true );
        Alt.Natives.TaskSetBlockingOfNonTemporaryEvents( ScriptId, true );
        Alt.Natives.SetPedSuffersCriticalHits( ScriptId, false );
        Alt.Natives.SetPedDropsWeaponsWhenDead( ScriptId, false );
        Alt.Natives.SetPedDiesInstantlyInWater( ScriptId, false );
        Alt.Natives.SetPedCanRagdoll( ScriptId, false );
        Alt.Natives.SetPedDiesWhenInjured( ScriptId, false );
        Alt.Natives.SetPedFleeAttributes( ScriptId, 0, false );
        Alt.Natives.SetPedConfigFlag( ScriptId, ( int ) EPedConfigFlag.CanFlyThruWindscreen, false );
        Alt.Natives.SetPedConfigFlag( ScriptId, ( int ) EPedConfigFlag.NoCriticalHits, true );
        Alt.Natives.SetPedConfigFlag( ScriptId, ( int ) EPedConfigFlag.NoWrithe, true );
        Alt.Natives.SetPedConfigFlag( ScriptId, ( int ) EPedConfigFlag.ShouldFixIfNoCollision, true );
        Alt.Natives.SetPedConfigFlag( ScriptId, (int) EPedConfigFlag.DisableHurt, true );
        Alt.Natives.SetPedConfigFlag( ScriptId, (int) EPedConfigFlag.KillWhenTrapped, true );
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