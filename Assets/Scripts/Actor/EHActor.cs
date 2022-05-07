using System.Collections.Generic;
using System.Net;
using EmptyHouseGames.ProjectTowerDefense.SpawnPool;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    /// <summary>
    /// Actors are the base object for all 
    /// </summary>
    public class EHActor : EHObject, IPoolable
    {
        public Animator Anim { get; private set; }
        private List<EHActorComponent> TickableActorComponents = new List<EHActorComponent>();

        protected override void Awake()
        {
            base.Awake();
            Anim = GetComponent<Animator>();
        }

        protected virtual void Start()
        {
            EHActorComponent[] AllActorComponents = GetComponentsInChildren<EHActorComponent>(true);
            foreach (EHActorComponent ActorComponent in AllActorComponents)
            {
                if (ActorComponent.IsTicking)
                {
                    TickableActorComponents.Add(ActorComponent);
                }
            }
        }
        
        #region getter/setter methods

        public Vector3 GetActorPosition()
        {
            return this.transform.position;
        }

        public Vector3 GetActorEulerRotation()
        {
            return this.transform.eulerAngles;
        }

        public Quaternion GetActorRotation()
        {
            return transform.rotation;
        }

        public Vector3 GetActorForwardVector()
        {
            return transform.forward;
        }

        public Vector3 GetActorRightVector()
        {
            return transform.right;
        }

        public Vector3 GetActorScale()
        {
            return transform.localScale;
        }
        
        public void SetActorPosition(Vector3 Position)
        {
            this.transform.position = Position;
        }

        public void SetActorRotation(Vector3 EulerAngles)
        {
            transform.rotation = Quaternion.Euler(EulerAngles);
        }

        public void SetActorRotation(Quaternion Rotation)
        {
            transform.rotation = Rotation;
        }

        public void SetActorForwardVector(Vector3 ForwardVector)
        {
            this.transform.forward = ForwardVector;
        }

        public void SetActorRightVector(Vector3 RightVector)
        {
            transform.right = RightVector;
        }

        public void SetActorScale(Vector3 Scale)
        {
            transform.localScale = Scale;
        }
        #endregion getter/setter methods

        public T CreateActor<T>(T ActorToCreate, Vector3 Position, Quaternion Rotation) where T : EHActor
        {
            return EHGameInstance.Instance.CreateActor(ActorToCreate, Position, Rotation);
        }

        public T CreateActor<T>(T ActorToCreate, Vector3 Position, Vector3 Rotation) where T : EHActor
        {
            return CreateActor(ActorToCreate, Position, Quaternion.Euler(Rotation));
        }
        
        #region interface overrides
        
        #endregion interface overrides
    }
}

