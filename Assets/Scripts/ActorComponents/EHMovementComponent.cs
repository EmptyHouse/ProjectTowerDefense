using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Physics;

namespace EmptyHouseGames.ProjectTowerDefense.ActorComponent
{
    [RequireComponent(typeof(EHPhysics))]
    public class EHMovementComponent : EHCharacterComponent
    {
        public float MovementAcceleration = 50;
        public float WalkingSpeed = 10;
        public float RunningSpeed = 20;

        private EHPhysics PhysicsComponent;

        private Vector2 CurrentInput;
        private Vector2 PreviousInput;
        private Vector3 Velocity;
        
        #region monobehaviour methods

        protected override void Awake()
        {
            base.Awake();
        }
        private void Update()
        {
            
        }
        #endregion monobehaviour methods

        public void SetMoveForwardInput(float VerticalInput)
        {
            PreviousInput.y = CurrentInput.y;
            CurrentInput.y = VerticalInput;
        }

        public void SetMoveRightInput(float HorizontalInput)
        {
            PreviousInput.x = CurrentInput.x;
            CurrentInput.x = HorizontalInput;
        }
    }
}

