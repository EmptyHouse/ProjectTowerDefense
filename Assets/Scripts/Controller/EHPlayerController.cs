using System;
using UnityEngine.InputSystem;
using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.DataTables;
using EmptyHouseGames.ProjectTowerDefense.Manager;

namespace EmptyHouseGames.ProjectTowerDefense.Controller
{
    public class EHPlayerController : EHBaseController
    {
        private struct PlayerControllerState
        {
            public float XAxis;
            public float YAxis;
            public Vector2 LookDirectionInput;
            public bool ActionButton;
            public bool AttackButton;
        }

        #region const values

        
        private const string MovementAxis = "Move";
        private const string ActionButton = "Action";
        private const string AttackButton = "Shoot";
        private const string LookDirectionAxis = "LookDirection";
        private const string MousePosition = "MousePosition";
        #endregion const values

        public PlayerInput PlayerInputMap;
        
        private InputAction MovementAction;
        private InputAction DirectionAction;
        private InputAction MouseDirectionAction;
        
        public EHCharacter PossessedCharacter; //{ get; private set; }
        public EHProjectileLauncher CachedProjectileLauncher;

        private Vector2 CurrentDirectionalInput;
        private PlayerControllerState ControllerState;
        private EHGameCamera PlayerCamera;
        //REMOVE THIS LATER
        [SerializeField]
        private string TurretIdString;
        #region monobehaviour methods
        protected override void Awake()
        {
            base.Awake();
            CurrentDirectionalInput = Vector2.zero;
            // REMOVE THIS LATER...
            if (PossessedCharacter != null) PossessPawn(PossessedCharacter);
            // May need to set this up somewhere else
            PlayerCamera = Camera.main.GetComponent<EHGameCamera>();
        }

        protected override void FixedUpdate()
        {
            base.FixedUpdate();
            UpdateMovementAxis();
            UpdateAimingAxis();
        }
        #endregion monobehaivour methods
        
        #region override functions
        public override void PossessPawn(EHPawn Pawn)
        {
            base.PossessPawn(Pawn);
            PossessedCharacter = (EHCharacter) Pawn;
            CachedProjectileLauncher = PossessedCharacter.GetComponent<EHProjectileLauncher>();
            SetUpInput();
        }
        
        public override void SetUpInput()
        {
            MovementAction = PlayerInputMap.actions[MovementAxis];
            // DirectionAction = PlayerInputMap.actions[LookDirectionAxis];
            MouseDirectionAction = PlayerInputMap.actions[MousePosition];
            PlayerInputMap.actions[AttackButton].performed += PlayerFireEvent;
            PlayerInputMap.actions[ActionButton].performed += PlaceTurretOnField;
        }
        #endregion override functions
        
        #region player controller events
        #endregion player controller events

        private void PlayerFireEvent(InputAction.CallbackContext Context)
        {
            CachedProjectileLauncher.ShootProjectile();
        }

        private void PlaceTurretOnField(InputAction.CallbackContext Context)
        {
            EHGameBoard GameBoard = GetGameState<EHGameState>().ActiveGameBoard;
            EHTowerDataTableRow TowerRow = GetGameInstance().GetDataTableManager().GetTowerDataRow(TurretIdString);
            GameBoard.PlaceUnitAtWorldPoint(this, PossessedCharacter.GetActorPosition(), TowerRow.TowerUnit);
        }

        private void UpdateMovementAxis()
        {
            Vector2 MovementAxis = MovementAction.ReadValue<Vector2>();
            // Adjust direction based on the camera direction
            Vector3 AdjustedInput = PlayerCamera.transform.TransformDirection(new Vector3(MovementAxis.x, 0, MovementAxis.y));
            MovementAxis.x = AdjustedInput.x;
            MovementAxis.y = AdjustedInput.z;
            if (MovementAxis.y != ControllerState.YAxis || MovementAxis.x != ControllerState.XAxis)
            {
                ControllerState.XAxis = MovementAxis.x;
                ControllerState.YAxis = MovementAxis.y;
                PossessedCharacter.MovementComponent.SetMovementInput(MovementAxis);
            }
        }

        private void UpdateAimingAxis()
        {
            Vector2 PlayerDirection = GetLookDirectionFromScreenPoint(MouseDirectionAction.ReadValue<Vector2>());
            if (ControllerState.LookDirectionInput != PlayerDirection)
            {
                ControllerState.LookDirectionInput = PlayerDirection;
                PossessedCharacter.MovementComponent.SetLookingInput(PlayerDirection);
            }
        }

        private Vector2 GetLookDirectionFromScreenPoint(Vector3 MousePosition)
        {
            Ray CameraRay = PlayerCamera.AssociatedCamera.ScreenPointToRay(MousePosition);
            Vector3 CameraHitPosition = CameraRay.origin + CameraRay.direction * (CameraRay.origin.y / -CameraRay.direction.y);
            Vector3 DirectionFromPlayer = CameraHitPosition - PossessedCharacter.GetActorPosition();
            return new Vector2(DirectionFromPlayer.x, DirectionFromPlayer.z);
        }

        
    }
}

