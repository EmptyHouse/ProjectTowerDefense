using System;
using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Actor;

[System.Serializable]
public struct FAttackData
{
    public int DamageAmount;
    [NonSerialized]
    public EHActor OwningActor;
}
public class EHAttackComponent : EHActorComponent
{
    
}
