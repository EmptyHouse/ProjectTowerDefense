using System;
using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Actor;

[System.Serializable]
public struct FHitData
{
    public int DamageAmount;
    [NonSerialized]
    public EHActor OwningActor;
}
public class EHAttackComponent : EHActorComponent
{
    
}
