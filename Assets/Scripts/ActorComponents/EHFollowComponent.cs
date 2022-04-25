using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EHFollowComponent : EHActorComponent
{
    public float Speed;
    public Transform Destination { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        IsTicking = true;
    }

    private void FixedUpdate()
    {
        Vector3 NextPosition = Vector3.MoveTowards(GetOwningActorLocation(), Destination.position, Time.fixedDeltaTime * Speed);
        SetOwningActorLocation(NextPosition);
    }

    public void SetNextDestination(Transform NextDestination)
    {
        Destination = NextDestination;
    }
}
