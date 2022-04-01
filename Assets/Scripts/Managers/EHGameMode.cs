using System.Collections.Generic;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    public class EHGameMode : EHGameManager
    {
        private EHGameState CachedGameState;
        private List<ITickable> TickableList = new List<ITickable>();
        #region monobehaviour methods

        protected void Awake()
        {
            //Remove This Later
            GameObject[] allMonoObjects = GameObject.FindObjectsOfType<GameObject>();
            foreach (GameObject obj in allMonoObjects)
            {
                TickableList.AddRange(obj.GetComponentsInChildren<ITickable>(true));
            }
        }

        private void FixedUpdate()
        {
            if (CachedGameState.CurrentMatchState == EMatchState.GamePlaying)
            {
                TickGame();
            }
        }

        #endregion monobehaviour methods

        private void TickGame()
        {
            foreach (ITickable Tickable in TickableList)
            {
                Tickable.Tick();
            }
        }
        
        public override void InitializeManager(FWorldSettings WorldSettings)
        {
            base.InitializeManager(WorldSettings);
            CachedGameState = EHGameInstance.Instance.GameState;
        }
    }
}
