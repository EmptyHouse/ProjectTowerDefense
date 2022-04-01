using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Controller
{
    public class EHBaseController : MonoBehaviour, ITickable
    {
        public EHPawn PossessedPawn { get; private set; }
        #region monobehaviour methods

        protected virtual void Awake()
        {
            
        }

        public virtual void Tick()
        {
            
        }
        #endregion monobehaviour methods
        
        public virtual void SetUpInput()
        {
        
        }

        public virtual void PossessPawn(EHPawn Pawn)
        {
            PossessedPawn = Pawn;
        }
    }
}

