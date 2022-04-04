using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Physics;

namespace EmptyHouseGames.ProjectTowerDefense.ActorComponent
{
    [RequireComponent(typeof(EHPhysics))]
    public class EHMovementComponent : EHCharacterComponent
    {
        private const float WalkJoystickThreshold = 0.1f;
        private const float RunJoystickThreshold = 0.6f;
        
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
            PhysicsComponent = GetComponent<EHPhysics>();
            IsTicking = true;
        }
        #endregion monobehaviour methods

        public override void Tick()
        {
            Velocity = new Vector3(CurrentInput.x, 0, CurrentInput.y).normalized * WalkingSpeed;
            PhysicsComponent.Velocity = Velocity;
        }

        public void SetMovementInput(Vector2 MovementInput)
        {
            PreviousInput = CurrentInput;
            CurrentInput = MovementInput;
        }

        public void SetLookingInput(Vector2 DirectionalInput)
        {
            float Rotation = Mathf.Rad2Deg * Mathf.Atan2(DirectionalInput.x, DirectionalInput.y);
            SetOwningActorRotation(new Vector3(0, Rotation, 0));
        }
    }
}

