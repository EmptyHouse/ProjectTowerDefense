using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Manager;

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

    public override void Tick()
    {
        base.Tick();
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
