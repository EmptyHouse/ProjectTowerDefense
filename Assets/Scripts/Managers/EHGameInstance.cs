using System.Data;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Controller;
using EmptyHouseGames.ProjectTowerDefense.DataTables;
using UnityEngine;
using UnityEngine.Serialization;


namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    [System.Serializable]
    public struct FWorldSettings
    {
        public EHGameMode GameMode;
        public EHGameHUD GameHUD;
        public EHGameState GameState;
        public EHPlayerController PlayerController;
        public EHPlayerState PlayerState;
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
        // May want to use a list for our player controller and player state in the future
        public EHPlayerController PlayerController { get; private set; }
        public EHPlayerState PlayerState { get; private set; }
        [SerializeField]
        private EHDataTableManager DataTableManager;

        #region monobehaviour methods

        private void Awake()
        {
            if (instance != null)
            {
                instance.InitializeGameWorld(WorldSettings);
                return;
            }

            instance = this;
            InitializeGameWorld(WorldSettings);
            // Initialize one time start managers
            DataTableManager?.InitializeManager();
        }
        #endregion monobehaviour methods
        /// <summary>
        /// This function will be called every time we Load a new active scene
        /// </summary>
        /// <param name="WorldSettings"></param>
        private void InitializeGameWorld(FWorldSettings WorldSettings)
        {
            if (GameState) Destroy(GameState.gameObject);
            if (GameMode) Destroy(GameMode.gameObject);
            if (GameHUD) Destroy(GameHUD.gameObject);
            if (PlayerController) Destroy(PlayerController.gameObject);
            if (PlayerState) Destroy(PlayerState.gameObject);

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
            
            GameState?.InitializeWorldManager(WorldSettings);
            GameMode?.InitializeWorldManager(WorldSettings);
            GameHUD?.InitializeWorldManager(WorldSettings);
            
            // Change this to instantiate the player controller in the game mode
            PlayerController = GameObject.FindObjectOfType<EHPlayerController>();
            PlayerState = GameObject.FindObjectOfType<EHPlayerState>();
        }

        public T CreateActor<T>(T ActorToCreate, Vector3 Position, Vector3 Rotation) where T : EHActor
        {
            T NewActor = Instantiate(ActorToCreate, Position, Quaternion.Euler(Rotation));
            if (GameMode)
            {
                GameMode.AddActor(NewActor);
            }

            NewActor.OnCreated();
            return NewActor;
        }

        #region scene management

        public void LoadNewScene()
        {
            
        }
        #endregion scene managment
        
        #region get managers
        
        public EHDataTableManager GetDataTableManager()
        {
            return DataTableManager;
        }
        #endregion get managers
    }
}
