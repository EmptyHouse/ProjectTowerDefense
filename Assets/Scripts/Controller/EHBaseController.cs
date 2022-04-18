using System;
using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.Controller
{
    public class EHBaseController : EHActor
    {
        public EHPawn PossessedPawn { get; private set; }
        #region monobehaviour methods

        protected override void Awake()
        {
            base.Awake();
            IsTicking = true;
        }

        protected virtual void FixedUpdate()
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

