using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    /// <summary>
    /// Game managers that can be active throughout the life of the game application. These do not need the world
    /// context to properly execute
    /// </summary>
    public interface IGameManager
    {
        public void InitializeManager();
    }
    
    /// <summary>
    /// Interface for managers that will exist in the world and need to know the world settings
    /// </summary>
    public interface IWorldManager
    {
        public void InitializeWorldManager(FWorldSettings WorldSettings);
    }
}