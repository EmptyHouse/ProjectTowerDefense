using UnityEngine;

using EmptyHouseGames.ProjectTowerDefense.Towers;

public class EHTurretStandard : EHTowerUnit
{
    public Transform RotationPivot;
    
    public override void Tick()
    {
        base.Tick();
        UpdateRotation();
    }

    private void UpdateRotation()
    {
        Vector3 Forward = transform.forward;
        Vector3 TargetDirection = TowerTarget.Position - Position;
        float angle = Mathf.Acos(Vector3.Dot(Forward, TargetDirection));
        RotationPivot.localRotation = Quaternion.Euler(0, angle * Mathf.Rad2Deg, 0);
    }
}
