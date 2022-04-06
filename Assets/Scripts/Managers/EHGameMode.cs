using System.Collections.Generic;
using System.Linq;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    public class EHGameMode : EHGameManager
    {
        private EHGameState CachedGameState;
        [SerializeField]//REMOVE THIS LATER
        private EHGameBoard GameBoardToSpawn;
        private List<EHActor> TickableList = new List<EHActor>();
        #region monobehaviour methods

        protected void Start()
        {
            //Remove This Later
            EHActor[] AllActorsInWorld = GameObject.FindObjectsOfType<EHActor>();
            foreach (EHActor obj in AllActorsInWorld)
            {
                if (obj.IsTicking) AddActor(obj);
            }

            EHGameBoard SpawnedBoard = Instantiate(GameBoardToSpawn, Vector3.zero, Quaternion.identity);
            EHGameInstance.Instance.GameState.SetActiveGameBoard(SpawnedBoard);
        }
        
        // Using Tick Game to ensure that game is fully repeatable
        private void FixedUpdate()
        {
            if (CachedGameState.CurrentMatchState == EMatchState.GamePlaying)
            {
                // Advances game forward 1 frame
                TickGame();
            }
            
        }

        #endregion monobehaviour methods

        private void TickGame()
        {
            foreach (EHActor TickableActor in TickableList)
            {
                if (!TickableActor.IsActive) continue;
                
                //Tick the base actor first, then all of its components
                TickableActor.Tick();
                TickableActor.TickComponents();
            }
        }
        
        public override void InitializeManager(FWorldSettings WorldSettings)
        {
            base.InitializeManager(WorldSettings);
            CachedGameState = EHGameInstance.Instance.GameState;
        }

        public void AddActor(EHActor Actor)
        {
            TickableList.Add(Actor);
        }
    }
}
