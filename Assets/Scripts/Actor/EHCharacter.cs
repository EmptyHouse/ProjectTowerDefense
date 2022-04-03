using EmptyHouseGames.ProjectTowerDefense.ActorComponent;
using EmptyHouseGames.ProjectTowerDefense.Physics;

namespace EmptyHouseGames.ProjectTowerDefense.Actor
{
    public class EHCharacter : EHPawn
    {
        public EHPhysics PhysicsComponent { get; private set; }
        public EHMovementComponent MovementComponent { get; private set; }
        
        #region monobehaviour methods

        protected override void Awake()
        {
            base.Awake();
            PhysicsComponent = GetComponent<EHPhysics>();
            MovementComponent = GetComponent<EHMovementComponent>();
            IsTicking = true;
        }
        #endregion monobehaviour methods
    }
}

