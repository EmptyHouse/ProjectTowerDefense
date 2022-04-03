using System.Collections.Generic;
using UnityEngine;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Controller;

namespace EmptyHouseGames.ProjectTowerDefense.Manager
{
    public class EHGameWorld
    {
        public LinkedList<EHActor> ActiveSpawnedActors { get; private set; } = new LinkedList<EHActor>();
        private List<EHPlayerController> AllPlayerControllers = new List<EHPlayerController>();

        public void InstantiateActor(EHActor ActorToSpawn, Vector3 Position, Vector3 Rotation, Transform Parent = null)
        {
            EHActor SpawnedActor = GameObject.Instantiate(ActorToSpawn, Position, Quaternion.Euler(Rotation), Parent);
            ActiveSpawnedActors.AddLast(SpawnedActor);
        }

        public void DestroyActor(EHActor ActorToDestroy)
        {
            if (!ActorToDestroy)
            {
                Debug.LogWarning("Attempting to destroy invalid actor");
                return;
            }

            if (!ActiveSpawnedActors.Contains(ActorToDestroy))
            {
                Debug.LogWarning("Could not find associated Actor: " + ActorToDestroy.name);
                return;
            }

            ActiveSpawnedActors.Remove(ActorToDestroy);
            GameObject.Destroy(ActorToDestroy.gameObject);
        }
    }
}