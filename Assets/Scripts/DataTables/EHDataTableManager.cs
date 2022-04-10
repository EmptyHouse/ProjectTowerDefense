using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.DataTables
{
    public class EHDataTableManager
    {
        [SerializeField]
        private EHTowerDataTable TowerTable;

        #region datatable getters
        public EHTowerDataTable GetTowerTable() => TowerTable;
        #endregion datatable getters
        
        #region datatable functions
        #endregion datatable functions
    }
}

