using UnityEngine;

using EmptyHouseGames.ProjectTowerDefense.Towers;
using EmptyHouseGames.ProjectTowerDefense.Manager;

public class EHTurretStandard : EHTowerUnit
{
    public Transform RotationPivot;
    
    public override void Tick()
    {
        base.Tick();
        UpdateRotation();
    }
    
    private void Start()
    {
        TowerTarget = EHGameInstance.Instance.PlayerController.PossessedCharacter;
    }

    private void UpdateRotation()
    {
        if (TowerTarget == null) return;
        
        Vector3 Forward = transform.forward;
        Vector3 TargetDirection = TowerTarget.Position - Position;
        float angle = Mathf.Atan2(TargetDirection.x, TargetDirection.z);
        RotationPivot.localRotation = Quaternion.Euler(0, angle * Mathf.Rad2Deg, 0);
    }
}
