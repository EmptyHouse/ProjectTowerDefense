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
        public Vector3 Position { get; private set; }
        public Vector3 Rotation { get; private set; }
        public Vector3 Scale { get; private set; }
        private List<EHActorComponent> TickableActorComponents = new List<EHActorComponent>();

        protected override void Awake()
        {
            base.Awake();
            Position = transform.position;
            Rotation = transform.eulerAngles;
            Scale = transform.localScale;
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

        // Goes through our list of tickable actor components and calls their tick function.
        public void TickComponents()
        {
            foreach (EHActorComponent TickableComponent in TickableActorComponents)
            {
                TickableComponent.Tick();
            }
        }

        public void SetActorPosition(Vector3 Position)
        {
            this.Position = Position;
            transform.position = Position;
        }

        public void SetActorRotation(Vector3 EulerAngles)
        {
            this.Rotation = EulerAngles;
            transform.rotation = Quaternion.Euler(EulerAngles);
        }

        public void SetActorScale(Vector3 Scale)
        {
            this.Scale = Scale;
            transform.localScale = Scale;
        }

        public T CreateActor<T>(T ActorToCreate, Vector3 Position, Vector3 Rotation) where T : EHActor
        {
            return EHGameInstance.Instance.CreateActor(ActorToCreate, Position, Rotation);
        }
        
        #region interface overrides
        
        #endregion interface overrides

        
    }
}

