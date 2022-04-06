using UnityEngine;
using UnityEngine.Events;

namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    public enum EMatchState
    {
        GamePaused,
        GamePlaying,
    }
    public class EHGameState : EHGameManager
    {
        public EMatchState CurrentMatchState { get; private set; }
        // OldState, NewState
        public UnityAction<EMatchState, EMatchState> OnMatchStateChanged;
        public EHPlayerInventory PlayerInventory { get; private set; } = new EHPlayerInventory();

        public EHGameBoard ActiveGameBoard { get; private set; }
        
        public override void InitializeManager(FWorldSettings WorldSettings)
        {
            base.InitializeManager(WorldSettings);
            SetNewGameState(EMatchState.GamePlaying);
            // Create board. Might be something we make in the game modekjh
            //ActiveGameBoard = Instantiate()
        }

        public void SetNewGameState(EMatchState NewMatchState)
        {
            if (CurrentMatchState == NewMatchState)
            {
                return;
            }

            EMatchState OldMatchState = CurrentMatchState;
            CurrentMatchState = NewMatchState;
            OnMatchStateChanged?.Invoke(OldMatchState, CurrentMatchState);
        }

        public void SetActiveGameBoard(EHGameBoard GameBoard)
        {
            this.ActiveGameBoard = GameBoard;
        }
    }
}

