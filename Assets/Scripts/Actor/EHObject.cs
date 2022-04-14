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

    // Tick our actor once per frame tick. Set to 1/60 frames
    public virtual void Tick()
    {
            
    }
    #endregion monobehaviour methods
    
    public void SetActorActive(bool IsActive)
    {
        this.IsActive = IsActive;
        this.gameObject.SetActive(IsActive);
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
        const string CloneKeyword = "(Clone)";
        this.name = this.name.Substring(0, this.name.Length - CloneKeyword.Length);
    }
    public void OnSpawned()
    {
        IsActive = true;
    }

    public void OnDespawned()
    {
        IsActive = false;
    }

    public string GetSpawnId()
    {
        return this.name;
    }
}
