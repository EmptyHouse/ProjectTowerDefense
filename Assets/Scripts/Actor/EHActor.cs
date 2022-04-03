using System.Collections.Generic;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    // May want to make it so that actors are rendered in the world and have a separate object that is not, but
    // can still be Ticked
    public class EHActor : MonoBehaviour
    {
        
        public Vector3 Position { get; private set; }
        public Vector3 Rotation { get; private set; }
        public Vector3 Scale { get; private set; }
        public bool IsActive { get; private set; }
        public bool IsTicking { get; protected set; } = false;// By default actors will not tick. You will need to set them
        private List<EHActorComponent> TickableActorComponents = new List<EHActorComponent>();

        protected virtual void Awake()
        {
            Position = transform.position;
            Rotation = transform.eulerAngles;
            Scale = transform.localScale;
            IsActive = gameObject.activeSelf;
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
        
        // Tick our actor once per frame tick. Set to 1/60 frames
        public virtual void Tick()
        {
            
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

        public void SetActorActive(bool IsActive)
        {
            this.IsActive = IsActive;
            this.gameObject.SetActive(IsActive);
        }
    }
}

