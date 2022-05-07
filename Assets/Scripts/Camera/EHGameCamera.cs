using System.Collections;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

public class EHGameCamera : EHActor
{
    public float TargetOffset = 5;
    public float CameraFollowSpeed = 0.6f;
    public Camera AssociatedCamera { get; private set; }
    private EHActor CameraTarget;

    protected override void Awake()
    {
        base.Awake();
        IsTicking = true;
        SetFollowTarget(GameObject.FindObjectOfType<EHCharacter>());
        AssociatedCamera = GetComponent<Camera>();
    }

    private void OnValidate()
    {
        transform.position = TargetOffset * transform.forward;
    }

    protected virtual void Update()
    {
        if (!CameraTarget) return;
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 TargetPosition = CameraTarget.Position + (transform.forward * TargetOffset);
        SetActorPosition(Vector3.Lerp(Position, TargetPosition, CameraFollowSpeed * Time.deltaTime));
    }

    public void SetFollowTarget(EHActor FollowTarget)
    {
        if (FollowTarget == null)
        {
            Debug.LogWarning("Assigning a null follow target to camera");
            return;
        }
        this.CameraTarget = FollowTarget;
    }

    public void SetTargetOffset(float TargetOffset)
    {
        this.TargetOffset = TargetOffset;
    }
    
    #region camera effects
    private Transform CameraTransform;
    private float CameraShakeDuration;
    private float CameraShakeIntensity;

    public void StartCameraShake(float CameraShakeDuration, float CameraShakeIntensity = 1)
    {
        if (this.CameraShakeIntensity > CameraShakeIntensity) return;
        
        float PreviousCameraShakeDuration = this.CameraShakeDuration;
        this.CameraShakeIntensity = CameraShakeIntensity;
        this.CameraShakeDuration = CameraShakeDuration;
        
        if (PreviousCameraShakeDuration > 0) return;
        // If we are not already in the middle of a camera shake event, start a new one
        StartCoroutine(PerformCameraShake());
    }

    public void CancelCameraShake()
    {
        CameraShakeDuration = 0;
    }
    
    private IEnumerator PerformCameraShake()
    {
        while (CameraShakeDuration > 0)
        {
            Vector2 randomPoint = Random.insideUnitCircle;
            CameraTransform.localPosition = new Vector3(randomPoint.x, randomPoint.y, 0) * CameraShakeIntensity;
            yield return null;
            CameraShakeDuration -= Time.deltaTime;
        }

        CameraTransform.localPosition = Vector3.zero;
    }
    #endregion camera effects
}
