using System;
using System.Collections;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

// NOTE: Projectiles will need to be put inside an spawn pool in the future
[RequireComponent(typeof(Rigidbody))]
public class EHBaseProjectile : EHActor
{
    private const string EnemyLayer = "Enemy";
    
    public float ProjectileRadius;
    public float LaunchSpeed;
    public float ProjectileDamage;
    [SerializeField]
    private FHitData HitData;

    private EHActor OwningActor;
    private Rigidbody CachedPhysics;
    private Vector3 PreviousPosition;
    private int ProjectileLayerMask;
    private const float MaxLifeTime = 5;
    
    #region monobehaviour methods

    protected override void Awake()
    {
        base.Awake();
        ProjectileLayerMask = LayerMask.NameToLayer(EnemyLayer);
        CachedPhysics = GetComponent<Rigidbody>();
        PreviousPosition = GetActorPosition();
        StartCoroutine(KillBackUpCoroutine());
    }

    protected virtual void FixedUpdate()
    {
        CheckForCollision();
        PreviousPosition = GetActorPosition();
    }

    #endregion monobehaivour methods

    private void CheckForCollision()
    {
        Vector3 ActorPosition = GetActorPosition();
        Vector3 Offset = ActorPosition - PreviousPosition;
        Ray ProjectileRay = new Ray(PreviousPosition, Offset);
        
        if (Physics.Raycast(ProjectileRay, out RaycastHit ProjectileHit, Offset.magnitude, ~ProjectileLayerMask))
        {
            EHDamageableComponent EnemyDamageComponent = ProjectileHit.collider.GetComponent<EHDamageableComponent>();
            if (EnemyDamageComponent != null)
            {
                EnemyDamageComponent.TakeDamage(HitData);
                Destroy(this.gameObject);//we will want to use a spawnpool for this later
            }
        }
    }

    public void SetOwner(EHActor OwningActor)
    {
        this.OwningActor = OwningActor;
    }

    public void LaunchProjectile(Vector3 LaunchDirection, EHActor OwningActor)
    {
        CachedPhysics.velocity = LaunchDirection * LaunchSpeed;
        SetActorForwardVector(CachedPhysics.velocity);
        SetOwner(OwningActor);
    }

    private IEnumerator KillBackUpCoroutine()
    {
        yield return new WaitForSeconds(MaxLifeTime);
        Destroy(this.gameObject);
    }
}
