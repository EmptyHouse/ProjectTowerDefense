using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Interfaces
{
    public interface IPoolable
    {
        // Called after an object has been spawned
        public void OnSpawned();
        // Called after an object has been despawned from the world
        public void OnDespawned();
        // This id is used to group pooled objects together
        public string GetSpawnId();
    }
}