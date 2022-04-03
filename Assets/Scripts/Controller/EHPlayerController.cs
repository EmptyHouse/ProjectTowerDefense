using UnityEngine.InputSystem;
using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Actor;

namespace EmptyHouseGames.ProjectTowerDefense.Controller
{
    public class EHPlayerController : EHBaseController
    {
        private struct PlayerControllerState
        {
            public float XAxis;
            public float YAxis;
            public bool ActionButton;
            public bool AttackButton;
        }
        
        #region const values
        private const string MoveRightAxis = "Move";
        private const string ActionButton = "";
        private const string AttackButton = "";
        #endregion const values

        public PlayerInput PlayerInputMap;
        private InputAction MoveRightAction;
        
        public EHCharacter PossessedCharacter; //{ get; private set; }

        private Vector2 CurrentDirectionalInput;
        private PlayerControllerState ControllerState;
        private EHGameCamera PlayerCamera;
        #region monobehaviour methods
        protected override void Awake()
        {
            base.Awake();
            CurrentDirectionalInput = Vector2.zero;
            // REMOVE THIS LATER...
            if (PossessedCharacter != null) PossessPawn(PossessedCharacter);
        }

        public override void Tick()
        {
            UpdateControllerAxes();
        }
        #endregion monobehaivour methods
        
        #region override functions
        public override void PossessPawn(EHPawn Pawn)
        {
            base.PossessPawn(Pawn);
            PossessedCharacter = (EHCharacter) Pawn;
            SetUpInput();
        }
        
        public override void SetUpInput()
        {
            MoveRightAction = PlayerInputMap.actions[MoveRightAxis];
        }
        #endregion override functions
        
        #region player controller events
        public void MoveForward(float Axis)
        {
            ControllerState.YAxis = Axis;
            PossessedCharacter.MovementComponent.SetMoveForwardInput(Axis);
        }

        public void MoveRight(float Axis)
        {
            ControllerState.XAxis = Axis;
            PossessedCharacter.MovementComponent.SetMoveRightInput(Axis);
        }
        #endregion player controller events

        private void UpdateControllerAxes()
        {
            Vector2 RightAxis = MoveRightAction.ReadValue<Vector2>();
            if (RightAxis.y != ControllerState.YAxis) MoveForward(RightAxis.y);
            if (RightAxis.x != ControllerState.XAxis) MoveRight(RightAxis.x);
        }
    }
}

