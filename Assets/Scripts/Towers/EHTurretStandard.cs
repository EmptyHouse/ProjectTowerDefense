using UnityEngine;

using EmptyHouseGames.ProjectTowerDefense.Towers;
using EmptyHouseGames.ProjectTowerDefense.Manager;

public class EHTurretStandard : EHTowerUnit
{
    public Transform RotationPivot;
    
    protected override void FixedUpdate()
    {
        base.FixedUpdate();
        UpdateRotation();
    }
    
    protected override void Start()
    {
        base.Start();
        TowerTarget = EHGameInstance.Instance.PlayerController.PossessedCharacter;
    }

    private void UpdateRotation()
    {
        if (TowerTarget == null) return;
        
        Vector3 Forward = transform.forward;
        Vector3 TargetDirection = TowerTarget.GetActorPosition() - GetActorPosition();
        float angle = Mathf.Atan2(TargetDirection.x, TargetDirection.z);
        RotationPivot.localRotation = Quaternion.Euler(0, angle * Mathf.Rad2Deg, 0);
    }
}
