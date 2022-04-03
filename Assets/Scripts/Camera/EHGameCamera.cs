using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

public class EHGameCamera : EHActor
{
    public float TargetOffset = 5;
    public float CameraFollowSpeed = 0.6f;
    private EHActor CameraTarget;

    protected override void Awake()
    {
        base.Awake();
        IsTicking = true;
        SetFollowTarget(GameObject.FindObjectOfType<EHCharacter>());
    }

    private void OnValidate()
    {
        transform.position = TargetOffset * transform.forward;
    }

    public override void Tick()
    {
        if (!CameraTarget) return;
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 TargetPosition = CameraTarget.Position + (transform.forward * TargetOffset);
        SetActorPosition(Vector3.Lerp(Position, TargetPosition, CameraFollowSpeed * EHTime.DeltaTime));
    }

    public void SetFollowTarget(EHActor FollowTarget)
    {
        if (FollowTarget == null)
        {
            Debug.Log("Assigning a null follow target to camera");
            return;
        }
        this.CameraTarget = FollowTarget;
    }

    public void SetTargetOffset(float TargetOffset)
    {
        this.TargetOffset = TargetOffset;
    }
}
