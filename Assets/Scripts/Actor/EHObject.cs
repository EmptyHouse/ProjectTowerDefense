using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Manager;

public class EHObject : MonoBehaviour
{
    public bool IsActive { get; private set; }
    public bool IsTicking { get; protected set; } = false;// By default actors will not tick. You will need to set them
    
    #region monobehaviour methods
    protected virtual void Awake()
    {
        IsActive = gameObject.activeSelf;
    }
    #endregion monobehaviour methods
    
    public void SetActorActive(bool IsActive)
    {
        this.IsActive = IsActive;
        gameObject.SetActive(IsActive);
    }
    
    public T GetGameState<T>() where T : EHGameState
    {
        return (T)EHGameInstance.Instance.GameState;
    }

    public T GetGameMode<T>() where T : EHGameMode
    {
        return (T)EHGameInstance.Instance.GameMode;
    }
    
    public EHGameInstance GetGameInstance()
    {
        return EHGameInstance.Instance;
    }
    
    public void OnCreated()
    {
        // Remove the clone keyword that is appended to every instantiated objects name
        const string CloneKeyword = "(Clone)";
        name = name.Substring(0, name.Length - CloneKeyword.Length);
    }
    public void OnSpawned()
    {
        SetActorActive(true);
    }

    public void OnDespawned()
    {
        SetActorActive(false);
    }

    public string GetSpawnId()
    {
        return name;
    }
}
