using EmptyHouseGames.ProjectTowerDefense.ActorComponent;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    public class EHCharacter : EHPawn
    {
        public Rigidbody PhysicsComponent { get; private set; }
        public EHMovementComponent MovementComponent { get; private set; }
        
        #region monobehaviour methods

        protected override void Awake()
        {
            base.Awake();
            PhysicsComponent = GetComponent<Rigidbody>();
            MovementComponent = GetComponent<EHMovementComponent>();
            IsTicking = true;
        }
        #endregion monobehaviour methods
    }
}

