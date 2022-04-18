

using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using UnityEngine;


public class EHMinionSpawner : EHActor
{
    public EHBaseMinion MinionToSpawn;
    public float DelayBetweenSpawn;
    private float TimeUntilNextSpawn;

    protected override void Awake()
    {
        base.Awake();
        IsTicking = true;
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
        if (TimeUntilNextSpawn < 0)
        {
            SpawnMinion();
        }
    }

    private void SpawnMinion()
    {
        EHBaseMinion Minion = Instantiate(MinionToSpawn, transform.position, transform.rotation);
        GetGameMode<EHGameMode>().AddActor(Minion);
    }
}
