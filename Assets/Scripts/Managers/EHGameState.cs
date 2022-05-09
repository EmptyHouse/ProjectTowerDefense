using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Controller;
using UnityEngine;
using UnityEngine.Events;

namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    public enum EMatchState
    {
        GamePaused,
        GamePlaying,
    }
    public class EHGameState : MonoBehaviour, IWorldManager
    {
        public EMatchState CurrentMatchState { get; private set; }
        public UnityAction<EMatchState, EMatchState> OnMatchStateChanged; // OldState, NewState
        public List<EHPlayerState> AllActivePlayerStates { get; private set; } = new List<EHPlayerState>();

        public EHGameBoard ActiveGameBoard { get; private set; }
        
        public virtual void InitializeWorldManager(FWorldSettings WorldSettings)
        {
            SetNewGameState(EMatchState.GamePlaying);
            // Create board. Might be something we make in the game mode
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
        
        /// <summary>
        /// Returns the player state at the given index
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public EHPlayerState GetPlayerStateAtIndex(int Index)
        {
            if (Index < 0 || Index >= AllActivePlayerStates.Count)
                return null;
            return AllActivePlayerStates[Index];
        }
        
        /// <summary>
        /// Returns the associated player controller at index
        /// </summary>
        /// <param name="Index"></param>
        /// <returns></returns>
        public EHPlayerController GetPlayerControllerAtIndex(int Index)
        {
            EHPlayerState PlayerState = GetPlayerStateAtIndex(Index);
            if (PlayerState == null) return null;
            return PlayerState.OwningPlayerController;
        }
    }
}

