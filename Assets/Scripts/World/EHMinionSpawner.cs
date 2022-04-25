

using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using UnityEngine;


public class EHMinionSpawner : EHActor
{
    public EHBaseMinion MinionToSpawn;
    public Transform DestinationPoint;
    public float DelayBetweenSpawn;
    private float TimeUntilNextSpawn;

    protected override void Awake()
    {
        base.Awake();
        TimeUntilNextSpawn = Time.time;
    }

    private void OnDrawGizmos()
    {
#if UNITY_EDITOR
        UnityEditor.Handles.color = Color.cyan;
        UnityEditor.Handles.SphereHandleCap(0, transform.position, Quaternion.identity, 2, EventType.Repaint);
#endif
    }

    protected virtual void FixedUpdate()
    {
        if (TimeUntilNextSpawn < Time.time)
        {
            SpawnMinion();
            TimeUntilNextSpawn += DelayBetweenSpawn;
        }
    }

    private void SpawnMinion()
    {
        EHBaseMinion Minion = CreateActor(MinionToSpawn, Position, Rotation);
        Minion.FollowComponent.SetNextDestination(DestinationPoint);
    }
}
