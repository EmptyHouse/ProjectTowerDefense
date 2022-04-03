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

        public EHGameBoard ActiveGameBoard;
        
        public override void InitializeManager(FWorldSettings WorldSettings)
        {
            base.InitializeManager(WorldSettings);
            SetNewGameState(EMatchState.GamePlaying);
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
    }
}

