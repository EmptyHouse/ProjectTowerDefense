using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

public class EHBaseMinion : EHPawn
{
    public EHFollowComponent FollowComponent { get; private set; }
    
    protected override void Awake()
    {
        base.Awake();
        FollowComponent = GetComponent<EHFollowComponent>();
        StartCoroutine(KillYourself());
    }

    private IEnumerator KillYourself()
    {
        yield return new WaitForSeconds(10);
        Destroy(gameObject);
    }
}
