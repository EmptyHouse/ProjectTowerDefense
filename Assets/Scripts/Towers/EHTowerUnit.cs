using System;
using System.Collections.Generic;
using UnityEngine;

using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Manager;

namespace EmptyHouseGames.ProjectTowerDefense.Towers
{
    [System.Serializable]
    public struct FTowerStats
    {
        // The duration of time between when each projectile is shot
        public float FireRate;
        public int DamagePerHit;
        public float AttackRadius;
    }
    
    public class EHTowerUnit : EHPlaceableUnit, ITickable
    {
        public FTowerStats TowerStats; //{ get; private set; }
        public EHCharacter TowerTarget { get; protected set; }
        private HashSet<EHCharacter> AllCharactersInRange = new HashSet<EHCharacter>();
        
        #region monobehaviour methods
        // Remove this later
        

        #endregion monobehaviour methods
        
        #region override methods
        public virtual void Tick()
        {
            
        }
        #endregion override methods

        public void SetTowerStats(FTowerStats TowerStats)
        {
            this.TowerStats = TowerStats;
        }

        public bool IsTargetInRange(Vector3 TargetPosition)
        {
            Vector2 OffsetPosition = new Vector2(Position.x - TargetPosition.x, Position.z - TargetPosition.z);
            return Vector2.SqrMagnitude(OffsetPosition) < TowerStats.AttackRadius * TowerStats.AttackRadius;
        }

        public void OnEnemyEntered(EHCharacter CharacterEntered)
        {
            AllCharactersInRange.Add(CharacterEntered);
            if (TowerTarget == null)
            {
                TowerTarget = CharacterEntered;
            }
        }

        public void OnEnemyExit(EHCharacter CharacterExited)
        {
            AllCharactersInRange.Remove(CharacterExited);
            if (CharacterExited == TowerTarget)
            {
                TowerTarget = GetClosestTarget();
            }
        }
        
        // Returns the closest target to our turret 
        private EHCharacter GetClosestTarget()
        {
            EHCharacter ClosestTarget = null;
            float MinDistance = 0;
            foreach (EHCharacter Target in AllCharactersInRange)
            {
                Vector2 OffsetPosition = new Vector2(Position.x - Target.Position.x, Position.z - Target.Position.z);
                float TargetSqrDistance = OffsetPosition.SqrMagnitude();
                if (ClosestTarget == null || TargetSqrDistance < MinDistance)
                {
                    MinDistance = TargetSqrDistance;
                    ClosestTarget = Target;
                }
            }
            return ClosestTarget;
        }
    }
}

