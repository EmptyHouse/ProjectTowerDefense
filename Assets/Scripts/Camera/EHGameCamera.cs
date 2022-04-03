using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

public class EHGameCamera : EHActor
{
    public Vector3 TargetOffset;
    private EHActor CameraTarget;

    protected override void Awake()
    {
        base.Awake();
    }

    private void OnValidate()
    {
        transform.position = TargetOffset;
    }

    public override void Tick()
    {
        if (!CameraTarget) return;
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 TargetPosition = CameraTarget.Position + TargetOffset;
        
    }

    public void SetFollowTarget(EHActor FollowTarget)
    {
        this.CameraTarget = FollowTarget;
    }

    public void SetTargetOffset(Vector3 TargetOffset)
    {
        this.TargetOffset = TargetOffset;
    }
}
