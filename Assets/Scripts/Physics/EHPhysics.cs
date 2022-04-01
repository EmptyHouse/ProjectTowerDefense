using EmptyHouseGames.ProjectTowerDefense;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Physics
{
    public class EHPhysics : EHActorComponent, ITickable
    {
        public Vector3 Velocity { get; set; }
    
        #region monobehaivour methods

        #endregion monobehaivour methods
    
        #region override methods

        public void Tick()
        {
            Vector3 ActorLocation = GetOwningActorLocation();
            // Want to add some collision checks here in the future
            SetOwningActorLocation(ActorLocation + (Velocity * EHTime.DeltaTime));
        }
        #endregion override methods
    }

}
