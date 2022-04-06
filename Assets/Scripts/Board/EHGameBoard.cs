using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using EmptyHouseGames.ProjectTowerDefense.Towers;
using UnityEngine;

public struct FBoardPosition
{
    public Vector2Int BoardIndex;
    public Vector3 WorldPosition;
    public bool Occupied;
}

public class EHGameBoard : EHActor
{
    public const float TileSize = 5f;
    
    public EHGameBoard ActiveGameBoard { get; private set; }
    public Vector2Int BoardSize = new Vector2Int(10, 10);
    private List<FBoardPosition> AllBoardTiles = new List<FBoardPosition>();
    private List<EHPlaceableUnit> AllPlacedUnits = new List<EHPlaceableUnit>();

    #region monobehaviour methods

    protected override void Awake()
    {
        base.Awake();
        
        for (int i = 0; i < AllBoardTiles.Count; ++i)
        {
            FBoardPosition BoardPosition = new FBoardPosition();
            BoardPosition.BoardIndex.x = i % BoardSize.x;
            BoardPosition.BoardIndex.y = i / BoardSize.x;
            AllBoardTiles.Add(new FBoardPosition());
        }
    }

    #endregion monobehaviour methods

    public FBoardPosition GetBoardPositionFromWorldPosition(Vector3 WorldPosition)
    {
        return GetBoardPosition(0, 0);
    }
    
    public FBoardPosition GetBoardPosition(int X, int Y)
    {
        int TileIndex = (BoardSize.x * Y) + X;
        if (TileIndex < 0 || TileIndex >= AllBoardTiles.Count) return new FBoardPosition();
        return AllBoardTiles[TileIndex];
    }

    public void PlaceUnitAtWorldPoint(EHPlaceableUnit Unit, Vector3 WorldPosition)
    {
        PlaceUnitAtBoardPosition(Unit, WorldPositionToBoardPosition(WorldPosition));
    }

    public void PlaceUnitAtBoardPosition(EHPlaceableUnit Unit, Vector2Int BoardPosition)
    {
        EHPlaceableUnit NewUnit =
            Instantiate<EHPlaceableUnit>(Unit, BoardPositionToWorldPosition(BoardPosition), Quaternion.identity);
        AllPlacedUnits.Add(NewUnit);
        GetGameMode<EHGameMode>().AddActor(NewUnit);

    }

    public Vector3 BoardPositionToWorldPosition(Vector2Int BoardPosition)
    {
        return new Vector3(BoardPosition.x * TileSize, 0, BoardPosition.y * TileSize);
    }

    public Vector2Int WorldPositionToBoardPosition(Vector3 WorldPosition)
    {
        return new Vector2Int(Mathf.FloorToInt(WorldPosition.x / TileSize), Mathf.FloorToInt(WorldPosition.z / TileSize));
    }
}
