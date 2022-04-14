using System.Collections;
using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.DataTables
{
    public class EHDataTableManager : IGameManager
    {
        [SerializeField]
        private EHTowerDataTable TowerTable;

        #region datatable getters
        public EHTowerDataTable GetTowerTable() => TowerTable;
        #endregion datatable getters
        
        #region datatable functions
        
        #endregion datatable functions
        // We will initialize all the data tables in this function
        public void InitializeManager()
        {
            TowerTable.InitializeManager();
        }
    }
}

