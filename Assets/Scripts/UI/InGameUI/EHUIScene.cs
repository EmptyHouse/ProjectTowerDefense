using EmptyHouseGames.ProjectTowerDefense.Manager;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class EHUIScene : MonoBehaviour
{
    public virtual void InitializeUIScene()
    {
        
    }

    public EHGameInstance GetGameInstance()
    {
        return EHGameInstance.Instance;
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
