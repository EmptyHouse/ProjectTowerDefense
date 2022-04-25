using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Actor;
using EmptyHouseGames.ProjectTowerDefense.Manager;
using EmptyHouseGames.ProjectTowerDefense.Towers;
using EmptyHouseGames.ProjectTowerDefense.Controller;
using UnityEngine;

public struct FBoardTile
{
    public Vector2Int BoardIndex;
    public Vector3 WorldPosition;
    public EHPlaceableUnit Unit;

    public bool IsOccupied => Unit != null;
}

public enum EBoardPlacementFailure
{
    None,
    TileOccupied,
}

public class EHGameBoard : EHActor
{
    public const float TileSize = 5f;
    
    public EHGameBoard ActiveGameBoard { get; private set; }
    public Vector2Int BoardSize = new Vector2Int(10, 10);
    private List<FBoardTile> AllBoardTiles = new List<FBoardTile>();
    private List<EHPlaceableUnit> AllPlacedUnits = new List<EHPlaceableUnit>();

    #region monobehaviour methods

    protected override void Awake()
    {
        base.Awake();
        
        for (int i = 0; i < AllBoardTiles.Count; ++i)
        {
            FBoardTile BoardPosition = new FBoardTile();
            BoardPosition.BoardIndex.x = i % BoardSize.x;
            BoardPosition.BoardIndex.y = i / BoardSize.x;
            AllBoardTiles.Add(new FBoardTile());
        }
    }

    #endregion monobehaviour methods

    public FBoardTile GetBoardPositionFromWorldPosition(Vector3 WorldPosition)
    {
        return GetBoardTile(0, 0);
    }

    public FBoardTile GetBoardTile(Vector2Int BoardPosition)
    {
        return GetBoardTile(BoardPosition.x, BoardPosition.y);
    }
    
    public FBoardTile GetBoardTile(int X, int Y)
    {
        int TileIndex = (BoardSize.x * Y) + X;
        if (TileIndex < 0 || TileIndex >= AllBoardTiles.Count) return new FBoardTile();
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

    public bool IsTileOccupied(Vector2Int BoardPosition)
    {
        FBoardTile BoardTile = GetBoardTile(BoardPosition);
        return BoardTile.IsOccupied;
    }

    // We will place the unit at this position as well as charge the player that added the tile at this point
    public bool SetUnitAtTilePosition(EHPlayerController SourcePlayer, Vector2Int BoardPosition, EHPlaceableUnit BoardUnit)
    {
        if (BoardUnit == null) return false;
        FBoardTile BoardTile = GetBoardTile(BoardPosition);
        if (BoardTile.IsOccupied) return false;
        BoardTile.Unit = BoardUnit;
        // TO-DO instantiate object at this position and charge the player for placing the item at this point
        return true;
    }

    public bool RemoveUnitAtTilePosition()
    {
        // TO-DO remove a valid unit from this position and return money to player
        return false;
    }
}
