using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Guns may move to becoming their own actor in the future...
public class EHShotGun : EHProjectileLauncher
{
    [Header("Shotgun Values")] 
    [SerializeField]
    private byte BulletCount = 5;
    [SerializeField, Range(0f, 1f)]
    private float Spread = .2f; 
    
    public override void ShootProjectile()
    {
        
        for (int i = 0; i < BulletCount; ++i)
        {
            Vector2 RandomCircle = Random.insideUnitCircle;
            Vector3 UpVec = LaunchPoint.up * RandomCircle.y * Spread;
            Vector3 RightVec = LaunchPoint.right * RandomCircle.x * Spread;
            Vector3 AdjustedForward = LaunchPoint.forward + UpVec + RightVec;
            EHBaseProjectile Projectile = CreateActor(ProjectileToLaunch, LaunchPoint.position, Quaternion.identity);
            Projectile.LaunchProjectile(AdjustedForward.normalized, OwningActor);
        }
    }
}
