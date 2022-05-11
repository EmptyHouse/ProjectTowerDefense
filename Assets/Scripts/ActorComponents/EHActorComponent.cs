using System;
using UnityEngine;

using EmptyHouseGames.ProjectTowerDefense.Actor;

public class EHActorComponent : MonoBehaviour
{
    public EHActor OwningActor { get; private set; }
    public bool IsTicking { get; protected set; }
    
    #region monobehaivour methods
    protected virtual void Awake()
    {
        OwningActor = GetComponent<EHActor>();
        if (OwningActor == null)
        {
            throw new ArgumentNullException("Actor Component Does Not Contain An Owning Actor");
        }
    }
    #endregion monobehaviour methods

    #region owning actor methods

    public T CreateActor<T>(T ActorToInstatiate, Vector3 Position, Quaternion Rotation) where T : EHActor
    {
        return OwningActor.CreateActor(ActorToInstatiate, Position, Rotation);
    }

    public T CreateActor<T>(T ActorToInstantiate, Vector3 Position, Vector3 Rotation) where T : EHActor
    {
        return OwningActor.CreateActor(ActorToInstantiate, Position, Rotation);
    }
    

    public Vector3 GetOwningActorLocation()
    {
        return OwningActor.GetActorPosition();
    }

    public Vector3 GetActorEulerRotation()
    {
        return OwningActor.GetActorEulerRotation();
    }

    public Quaternion GetActorRotation()
    {
        return OwningActor.GetActorRotation();
    }

    public Vector3 GetOwningActorScale()
    {
        return OwningActor.GetActorScale();
    }
    
    public void SetOwningActorLocation(Vector3 Location)
    {
        OwningActor.SetActorPosition(Location);
    }

    public void SetOwningActorRotation(Vector3 Rotation)
    {
        OwningActor.SetActorRotation(Rotation);
    }

    public void SetOwningActorRotation(Quaternion Rotation)
    {
        OwningActor.SetActorRotation(Rotation);
    }

    public void SetOwningActorScale(Vector3 Scale)
    {
        OwningActor.SetActorScale(Scale);
    }
    #endregion owning actor methods
}
