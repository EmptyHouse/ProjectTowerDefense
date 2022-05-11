using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using UnityEngine;

public class EHProjectileLauncher : EHActorComponent
{
    public EHBaseProjectile ProjectileToLaunch;
    public Transform LaunchPoint;
    public float FireRate;
    private float TimeTillNextFire;

    protected override void Awake()
    {
        base.Awake();
        IsTicking = true;
    }

    public virtual void ShootProjectile()
    {
        EHBaseProjectile Projectile = CreateActor(ProjectileToLaunch, LaunchPoint.position, Quaternion.identity);
        Projectile.LaunchProjectile(LaunchPoint.forward, OwningActor);
    }
}
