using EmptyHouseGames.ProjectTowerDefense.Manager;
using UnityEngine;

/// <summary>
/// All UI elements should be a child of EHUIElement. This is what our UI HUD will search for when initializing
/// </summary>
public class EHUIElement : MonoBehaviour
{
    public virtual void InitializeUIElement()
    {
        
    }

    public EHGameInstance GetGameInstance()
    {
        return EHGameInstance.Instance;
    }
    
    // Be careful about reading from the Game Mode. Clients do not have a reference to the game mode
    // if there is data that is needed, be sure to use the game state instead
    public T GetGameMode<T>() where T : EHGameMode
    {
        return (T)EHGameInstance.Instance.GameMode;
    }

    public T GetGameState<T>() where T : EHGameState
    {
        return (T) EHGameInstance.Instance.GameState;
    }

    public T GetGameHud<T>() where T : EHGameHUD
    {
        return (T) EHGameInstance.Instance.GameHUD;
    }
}
