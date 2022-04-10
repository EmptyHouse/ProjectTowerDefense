using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.SpawnPool
{
    public interface IPoolable
    {
        // Called after an object has been spawned
        public void OnSpawned();
        // Called after an object has been despawned from the world
        public void OnDespawned();
        // This function will only be called once upon its first creation through the spawn pool manager
        public void OnCreated();
        // This id is used to group pooled objects together
        public string GetSpawnId();
    }
}