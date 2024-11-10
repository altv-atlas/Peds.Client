#pragma warning disable CS1591 // Missing XML comment for publicly visible type or member
namespace AltV.Atlas.Peds.Client.Enums;

/// <summary>
/// Contains all the known values for ped config flags
/// Use with Alt.Natives.SetPedConfigFlag.
/// </summary>
public enum EPedConfigFlag
{
    NoCriticalHits = 2,
    DrownsInWater = 3,
    DisableReticuleFixedLockon = 4,
    UpperBodyDamageAnimsOnly = 7,
    NeverLeavesGroup = 13,
    BlockNonTemporaryEvents = 17,
    CanPunch = 18,
    IgnoreSeenMelee = 24,
    GetOutUndriveableVehicle = 29,
    CanFlyThruWindscreen = 32,
    DiesWhenRagdoll = 33,
    HasHelmet = 34,
    PutOnMotorcycleHelmet = 35,
    DontTakeOffHelmet = 36,
    DisableEvasiveDives = 39,
    DontInfluenceWantedLevel = 42,
    DisablePlayerLockon = 43,
    DisableLockonToRandomPeds = 44,
    AllowLockonToFriendlyPlayers = 45,
    BeingDeleted = 47,
    BlockWeaponSwitching = 48,
    NoCollision = 52,
    IsShooting = 58,
    WasShooting = 59,
    IsOnGround = 60,
    WasOnGround = 61,
    InVehicle = 62,
    OnMount = 63,
    AttachedToVehicle = 64,
    IsSwimming = 65,
    WasSwimming = 66,
    IsSkiing = 67,
    IsSitting = 68,
    KilledByStealth = 69,
    KilledByTakedown = 70,
    Knockedout = 71,
    IsSniperScopeActive = 72,
    SuperDead = 73,
    UsingCoverPoint = 75,
    IsInTheAir = 76,
    IsAimingGun = 78,
    ForcePedLoadCover = 93,
    VaultFromCover = 97,
    IsDrunk = 100,
    ForcedAim = 101,
    IsNotRagdollAndNotPlayingAnim = 104, // OpenDoorArmIK
    ForceReload = 105,
    DontActivateRagdollFromVehicleImpact = 106,
    DontActivateRagdollFromBulletImpact = 107,
    DontActivateRagdollFromExplosions = 108,
    DontActivateRagdollFromFire = 109,
    DontActivateRagdollFromElectrocution = 110,
    KeepWeaponHolsteredUnlessFired = 113,
    GetOutBurningVehicle = 116,
    BumpedByPlayer = 117,
    RunFromFiresAndExplosions = 118,
    TreatAsPlayerDuringTargeting = 119,
    IsHandCuffed = 120,
    IsAnkleCuffed = 121,
    DisableMelee = 122,
    DisableUnarmedDrivebys = 123,
    JustGetsPulledOutWhenElectrocuted = 124,
    NmMessage466 = 125,
    WillNotHotwireLawEnforcementVehicle = 126,
    WillCommandeerRatherThanJack = 127,
    CanBeAgitated = 128,
    ForcePedToFaceLeftInCover = 129,
    ForcePedToFaceRightInCover = 130,
    BlockPedFromTurningInCover = 131,
    KeepRelationshipGroupAfterCleanUp = 132,
    ForcePedToBeDragged = 133,
    PreventPedFromReactingToBeingJacked = 134,
    IsScuba = 135,
    WillArrestRatherThanJack = 136,
    RemoveDeadExtraFarAway = 137,
    RidingTrain = 138,
    ArrestResult = 139,
    CanAttackFriendly = 140,
    WillJackAnyPlayer = 141,
    WillJackWantedPlayersRatherThanStealCar = 144,
    ShootingAnimFlag = 145,
    DisableLadderClimbing = 146,
    StairsDetected = 147,
    SlopeDetected = 148,
    CowerInsteadOfFlee = 150,
    CanActivateRagdollWhenVehicleUpsideDown = 151,
    AlwaysRespondToCriesForHelp = 152,
    DisableBloodPoolCreation = 153,
    ShouldFixIfNoCollision = 154,
    CanPerformArrest = 155,
    CanPerformUncuff = 156,
    CanBeArrested = 157,
    PlayerPreferFrontSeatMP = 159,
    IsInjured = 166,
    DontEnterVehiclesInPlayersGroup = 167,
    PreventAllMeleeTaunts = 169,
    IsInjured2 = 170, // ForceDirectEntry
    AlwaysSeeApproachingVehicles = 171,
    CanDiveAwayFromApproachingVehicles = 172,
    AllowPlayerToInterruptVehicleEntryExit = 173,
    OnlyAttackLawIfPlayerIsWanted = 174,
    PedsJackingMeDontGetIn = 177,
    PedIgnoresAnimInterruptEvents = 179,
    IsInCustody = 180,
    ForceStandardBumpReactionThresholds = 181,
    LawWillOnlyAttackIfPlayerIsWanted = 182,
    IsAgitated = 183,
    PreventAutoShuffleToDriversSeat = 184,
    UseKinematicModeWhenStationary = 185,
    EnableWeaponBlocking = 186,
    HasHurtStarted = 187,
    DisableHurt = 188,
    PlayerIsWeird = 189,
    DoNothingWhenOnFootByDefault = 193,
    UsingScenario = 194,
    VisibleOnScreen = 195,
    DontActivateRagdollOnVehicleCollisionWhenDead = 199,
    HasBeenInArmedCombat = 200,
    AvoidanceIgnoreAll = 202,
    AvoidanceIgnoredByAll = 203,
    AvoidanceIgnoreGroup1 = 204,
    AvoidanceMemberOfGroup1 = 205,
    ForcedToUseSpecificGroupSeatIndex = 206,
    DisableExplosionReactions = 208,
    DodgedPlayer = 209,
    WaitingForPlayerControlInterrupt = 210,
    ForcedToStayInCover = 211,
    GeneratesSoundEvents = 212,
    ListensToSoundEvents = 213,
    AllowToBeTargetedInAVehicle = 214,
    WaitForDirectEntryPointToBeFreeWhenExiting = 215,
    OnlyRequireOnePressToExitVehicle = 216,
    ForceExitToSkyDive = 217,
    DontEnterLeadersVehicle = 220,
    DisableExitToSkyDive = 221,
    Shrink = 223,
    MeleeCombat = 224,
    DisablePotentialToBeWalkedIntoResponse = 225,
    DisablePedAvoidance = 226,
    ForceRagdollUponDeath = 227,
    DisablePanicInVehicle = 229,
    AllowedToDetachTrailer = 230,
    IsHoldingProp = 236,
    BlocksPathingWhenDead = 237,
    ForceSkinCharacterCloth = 240,
    DisableStoppingVehicleEngine = 241,
    PhoneDisableTextingAnimations = 242,
    PhoneDisableTalkingAnimations = 243,
    PhoneDisableCameraAnimations = 244,
    DisableBlindFiringInShotReactions = 245,
    AllowNearbyCoverUsage = 246,
    CanPlayInCarIdles = 248,
    CanAttackNonWantedPlayerAsLaw = 249,
    WillTakeDamageWhenVehicleCrashes = 250,
    AICanDrivePlayerAsRearPassenger = 251,
    PlayerCanJackFriendlyPlayers = 252,
    IsOnStairs = 253,
    AIDriverAllowFriendlyPassengerSeatEntry = 255,
    AllowMissionPedToUseInjuredMovement = 257,
    PreventUsingLowerPrioritySeats = 261,
    DisableClosingVehicleDoor = 264,
    TeleportToLeaderVehicle = 268,
    AvoidanceIgnoreWeirdPedBuffer = 269,
    OnStairSlope = 270,
    DontBlipCop = 272,
    ClimbedShiftedFence = 273,
    KillWhenTrapped = 275,
    EdgeDetected = 276,
    AvoidTearGas = 279,
    NoWrithe = 281, // DisableGoToWritheWhenInjured
    OnlyUseForcedSeatWhenEnteringHeliInGroup = 282,
    DisableWeirdPedEvents = 285,
    ShouldChargeNow = 286,
    RagdollingOnBoat = 287,
    HasBrandishedWeapon = 288,
    FreezePosition = 292,
    DisableShockingEvents = 294,
    NeverReactToPedOnRoof = 296,
    DisableShockingDrivingOnPavementEvents = 299,
    DisablePedConstraints = 301,
    ForceInitialPeekInCover = 302,
    DisableJumpingFromVehiclesAfterLeader = 305,
    IsInCluster = 310,
    ShoutToGroupOnPlayerMelee = 311,
    IgnoredByAutoOpenDoors = 312,
    NoPedMelee = 314, // ForceIgnoreMeleeActiveCombatant
    CheckLoSForSoundEvents = 315,
    CanSayFollowedByPlayerAudio = 317,
    ActivateRagdollFromMinorPlayerContact = 318,
    ForcePoseCharacterCloth = 320,
    HasClothCollisionBounds = 321,
    HasHighHeels = 322,
    DontBehaveLikeLaw = 324,
    DisablePoliceInvestigatingBody = 326,
    DisableWritheShootFromGround = 327,
    LowerPriorityOfWarpSeats = 328,
    DisableTalkTo = 329,
    DontBlip = 330,
    IsSwitchingWeapon = 331,
    IgnoreLegIkRestrictions = 332,
    AllowTaskDoNothingTimeslicing = 339,
    NotAllowedToJackAnyPlayers = 342,
    AlwaysLeaveTrainUponArrival = 345,
    OnlyWritheFromWeaponDamage = 347,
    UseSloMoBloodVfx = 348,
    EquipJetpack = 349,
    PreventDraggedOutOfCarThreatResponse = 350,
    ForceDeepSurfaceCheck = 356,
    DisableDeepSurfaceAnims = 357,
    DontBlipNotSynced = 358,
    IsDuckingInVehicle = 359,
    PreventAutoShuffleToTurretSeat = 360,
    DisableEventInteriorStatusCheck = 361,
    HasReserveParachute = 362,
    UseReserveParachute = 363,
    TreatDislikeAsHateWhenInCombat = 364,
    OnlyUpdateTargetWantedIfSeen = 365,
    AllowAutoShuffleToDriversSeat = 366,
    PreventReactingToSilencedCloneBullets = 372,
    DisableInjuredCryForHelpEvents = 373,
    NeverLeaveTrain = 374,
    DontDropJetpackOnDeath = 375,
    DisableAutoEquipHelmetsInBikes = 380,
    IsClimbingLadder = 388,
    HasBareFeet = 389,
    GoOnWithoutVehicleIfItIsUnableToGetBackToRoad = 391,
    BlockDroppingHealthSnacksOnDeath = 392,
    ForceThreatResponseToNonFriendToFriendMeleeActions = 394,
    DontRespondToRandomPedsDamage = 395,
    AllowContinuousThreatResponseWantedLevelUpdates = 396,
    KeepTargetLossResponseOnCleanup = 397,
    PlayersDontDragMeOutOfCar = 398,
    BroadcastRepondedToThreatWhenGoingToPointShooting = 399,
    IgnorePedTypeForIsFriendlyWith = 400,
    TreatNonFriendlyAsHateWhenInCombat = 401,
    DontLeaveVehicleIfLeaderNotInVehicle = 402,
    AllowMeleeReactionIfMeleeProofIsOn = 404,
    UseNormalExplosionDamageWhenBlownUpInVehicle = 407,
    DisableHomingMissileLockForVehiclePedInside = 408,
    DisableTakeOffScubaGear = 409,
    Alpha = 410, // IgnoreMeleeFistWeaponDamageMult
    LawPedsCanFleeFromNonWantedPlayer = 411,
    ForceBlipSecurityPedsIfPlayerIsWanted = 412,
    IsHolsteringWeapon = 413,
    UseGoToPointForScenarioNavigation = 414,
    DontClearLocalPassengersWantedLevel = 415,
    BlockAutoSwapOnWeaponPickups = 416,
    ThisPedIsATargetPriorityForAI = 417,
    IsSwitchingHelmetVisor = 418,
    ForceHelmetVisorSwitch = 419,
    FlamingFootprints = 421, // UseOverrideFootstepPtFx
    DisableVehicleCombat = 422,
    DisablePropKnockOff = 423,
    FallsLikeAircraft = 424,
    UseLockpickVehicleEntryAnimations = 426,
    IgnoreInteriorCheckForSprinting = 427,
    SwatHeliSpawnWithinLastSpottedLocation = 428,
    DisableStartingVehicleEngine = 429,
    IgnoreBeingOnFire = 430,
    DisableTurretOrRearSeatPreference = 431,
    DisableWantedHelicopterSpawning = 432,
    UseTargetPerceptionForCreatingAimedAtEvents = 433,
    DisableHomingMissileLockon = 434,
    ForceIgnoreMaxMeleeActiveSupportCombatants = 435,
    StayInDefensiveAreaWhenInVehicle = 436,
    DontShoutTargetPosition = 437,
    DisableHelmetArmor = 438,
    PreventVehExitDueToInvalidWeapon = 441,
    IgnoreNetSessionFriendlyFireCheckForAllowDamage = 442,
    DontLeaveCombatIfTargetPlayerIsAttackedByPolice = 443,
    CheckLockedBeforeWarp = 444,
    DontShuffleInVehicleToMakeRoom = 445,
    GiveWeaponOnGetup = 446,
    DontHitVehicleWithProjectiles = 447,
    DisableForcedEntryForOpenVehiclesFromTryLockedDoor = 448,
    FiresDummyRockets = 449,
    IsArresting = 450,
    IsDecoyPed = 451,
    HasEstablishedDecoy = 452,
    BlockDispatchedHelicoptersFromLanding = 453,
    DontCryForHelpOnStun = 454,
    CanBeIncapacitated = 456,
    MutableForcedAim = 457,
    DontChangeTargetFromMelee = 458
}