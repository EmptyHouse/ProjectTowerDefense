using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Physics;
using UnityEngine;

[RequireComponent(typeof(EHPhysics))]
public class EHFollowComponent : EHActorComponent
{
    public float Speed;
    public Transform Destination;

    protected override void Awake()
    {
        base.Awake();
        IsTicking = true;
    }

    public override void Tick()
    {
        base.Tick();
    }
}
