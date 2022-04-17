using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

// NOTE: Projectiles will need to be put inside an spawn pool in the future
[RequireComponent(typeof(Rigidbody))]
public class EHBaseProjectile : EHActor
{
    public float ProjectileRadius;
    public float LaunchSpeed;
    public float ProjectileDamage;

    private EHActor OwningActor;
    private Rigidbody CachedPhysics;
    
    #region monobehaviour methods

    protected override void Awake()
    {
        base.Awake();
        CachedPhysics = GetComponent<Rigidbody>();
    }

    #endregion monobehaivour methods

    public void SetOwner(EHActor OwningActor)
    {
        this.OwningActor = OwningActor;
    }

    public void LaunchProjectile(Vector3 LaunchDirection)
    {
        CachedPhysics.velocity = LaunchDirection * LaunchSpeed;
    }
}
