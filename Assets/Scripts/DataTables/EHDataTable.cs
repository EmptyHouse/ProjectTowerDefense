using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace EmptyHouseGames.ProjectTowerDefense.DataTables
{
    public class EHDataTableRow
    {
        public string RowId;
    }
    
    public class EHDataTable : ScriptableObject
    {
        public List<EHDataTableRow> Rows = new List<EHDataTableRow>();
        protected readonly Dictionary<string, EHDataTableRow> RowDictionary = new Dictionary<string, EHDataTableRow>();

        public virtual void InitializeDataTable()
        {
            foreach (EHDataTableRow Row in Rows)
            {
                RowDictionary.Add(Row.RowId, Row);
            }
        }

        public EHDataTableRow FindRowById(string RowId)
        {
            return RowDictionary.ContainsKey(RowId) ? RowDictionary[RowId] : null;
        }
    }
}

