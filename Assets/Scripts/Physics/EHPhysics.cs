using EmptyHouseGames.ProjectTowerDefense;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Physics
{
    public class EHPhysics : EHActorComponent
    {
        public Vector3 Velocity { get; set; }
    
        #region monobehaivour methods

        protected override void Awake()
        {
            base.Awake();
            IsTicking = true;
        }

        #endregion monobehaivour methods
    
        #region override methods

        public override void Tick()
        {
            Vector3 ActorLocation = GetOwningActorLocation();
            // Want to add some collision checks here in the future
            SetOwningActorLocation(ActorLocation + (Velocity * EHTime.DeltaTime));
        }
        #endregion override methods
    }

}
