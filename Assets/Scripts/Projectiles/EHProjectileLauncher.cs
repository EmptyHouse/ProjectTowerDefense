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

    public void ShootProjectile()
    {
        EHBaseProjectile Projectile = Instantiate(ProjectileToLaunch, LaunchPoint.position, Quaternion.identity);
        EHGameInstance.Instance.GameMode.AddActor(Projectile);
        Projectile.LaunchProjectile(LaunchPoint.forward);
    }
}
