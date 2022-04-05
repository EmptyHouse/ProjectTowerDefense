using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Physics;
using UnityEngine;

// NOTE: Projectiles will need to be put inside an spawn pool in the future
[RequireComponent(typeof(EHPhysics))]
public class EHBaseProjectile : EHActor
{
    public float ProjectileRadius;
    public float LaunchSpeed;
    public float ProjectileDamage;

    private EHActor OwningActor;
    private EHPhysics CachedPhysics;
    
    #region monobehaviour methods

    protected override void Awake()
    {
        base.Awake();
        CachedPhysics = GetComponent<EHPhysics>();
    }

    #endregion monobehaivour methods

    public void SetOwner(EHActor OwningActor)
    {
        this.OwningActor = OwningActor;
    }

    public void LaunchProjectile(Vector3 LaunchDirection)
    {
        CachedPhysics.Velocity = LaunchDirection * LaunchSpeed;
    }
}
