using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Controller;
using UnityEngine;


namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    [System.Serializable]
    public struct FWorldSettings
    {
        public EHGameMode GameMode;
        public EHGameHUD GameHUD;
        public EHGameState GameState;
        public EHPlayerController PlayerController;
    }
    /// <summary>
    /// The Game Instance is an object that persists throughout the duration of the game's life. You can use this to reference
    /// other game managers in the world
    /// </summary>
    public class EHGameInstance : MonoBehaviour
    {
        private static EHGameInstance instance;
        public static EHGameInstance Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = GameObject.FindObjectOfType<EHGameInstance>();
                }

                return instance;
            }
        }

        public FWorldSettings WorldSettings;
        
        public EHGameState GameState { get; private set; }
        public EHGameMode GameMode { get; private set; }
        public EHGameHUD GameHUD { get; private set; }

        #region monobehaviour methods

        private void Awake()
        {
            if (instance != null)
            {
                instance.InitializeGameInstance(WorldSettings);
                return;
            }

            instance = this;
            InitializeGameInstance(WorldSettings);
        }
        #endregion monobehaviour methods
        private void InitializeGameInstance(FWorldSettings WorldSettings)
        {
            if (GameState) Destroy(GameState.gameObject);
            if (GameMode) Destroy(GameMode.gameObject);
            if (GameHUD) Destroy(GameHUD.gameObject);

            if (WorldSettings.GameState != null)
            {
                GameState = Instantiate(WorldSettings.GameState);
                GameState.transform.SetParent(this.transform);
            }

            if (WorldSettings.GameMode != null)
            {
                GameMode = Instantiate(WorldSettings.GameMode);
                GameMode.transform.SetParent(this.transform);
            }

            if (WorldSettings.GameHUD != null)
            {
                GameHUD = Instantiate(WorldSettings.GameHUD);
                GameHUD.transform.SetParent(this.transform);
            }
            
            GameState?.InitializeManager(WorldSettings);
            GameMode?.InitializeManager(WorldSettings);
            GameHUD?.InitializeManager(WorldSettings);
        }
        
        #region scene management

        public void LoadNewScene()
        {
            
        }
        #endregion scene managment
    }
}
