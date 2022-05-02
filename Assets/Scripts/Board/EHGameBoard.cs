using System.Collections.Generic;
using EmptyHouseGames.ProjectTowerDefense.Actor;
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
    public const float BoardTileSize = 5f;

    public EHGameBoard ActiveGameBoard { get; private set; }
    public Vector2Int BoardSize = new Vector2Int(10, 10);
    private FBoardTile[] AllBoardTiles;
    private List<EHPlaceableUnit> AllPlacedUnits = new List<EHPlaceableUnit>();

    #region monobehaviour methods

    protected override void Awake()
    {
        base.Awake();
        int TileCount = BoardSize.x * BoardSize.y;
        AllBoardTiles = new FBoardTile[TileCount];
        // We may want to skip this step in the future
        for (int i = 0; i < TileCount; ++i)
        {
            AllBoardTiles[i].BoardIndex.x = i % BoardSize.x;
            AllBoardTiles[i].BoardIndex.y = i / BoardSize.x;
        }
    }

    #endregion monobehaviour methods

    public bool GetBoardTile(Vector2Int BoardPosition, out FBoardTile BoardTile)
    {
        return GetBoardTile(BoardPosition.x, BoardPosition.y, out BoardTile);
    }
    
    public bool GetBoardTile(int X, int Y, out FBoardTile BoardTile)
    {
        int TileIndex = (BoardSize.x * Y) + X;

        if (TileIndex < 0 || TileIndex >= AllBoardTiles.Length)
        {
            BoardTile = default;
            return false;
        }
        BoardTile = AllBoardTiles[TileIndex];
        return true;
    }

    public void PlaceUnitAtWorldPoint(EHPlayerController SourcePlayer, Vector3 WorldPosition, EHPlaceableUnit Unit)
    {
        SetUnitAtTilePosition(SourcePlayer, WorldSpaceToBoardSpace(WorldPosition), Unit);
    }

    public bool IsTileOccupied(Vector2Int BoardPosition)
    {
        return GetBoardTile(BoardPosition, out FBoardTile BoardTile) ? BoardTile.IsOccupied : false;
    }

    public bool IsTileOccupied(int X, int Y)
    {
        return GetBoardTile(X, Y, out FBoardTile BoardTile) ? BoardTile.IsOccupied : false;
    }

    // We will place the unit at this position as well as charge the player that added the tile at this point
    public bool SetUnitAtTilePosition(EHPlayerController SourcePlayer, Vector2Int BoardPosition, EHPlaceableUnit BoardUnit)
    {
        if (BoardUnit == null) return false;
        if (!GetBoardTile(BoardPosition, out FBoardTile BoardTile)) return false;
        if (BoardTile.IsOccupied) return false;
        EHPlaceableUnit NewUnit = CreateActor(BoardUnit, BoardSpaceToWorldSpace(BoardPosition), Vector3.zero);
        BoardTile.Unit = NewUnit;
        return true;
    }
    
    

    public bool RemoveUnitAtTilePosition(EHPlayerController SourcePlayer, Vector2Int BoardPosition)
    {
        if (!GetBoardTile(BoardPosition, out FBoardTile BoardTile)) return false;
        
        if (!BoardTile.Unit)
        {
            return false;
        }
        Destroy(BoardTile.Unit.gameObject);
        BoardTile.Unit = null;
        return false;
    }
    
    #region static functions
    public static Vector2Int WorldSpaceToBoardSpace(Vector3 WorldSpace)
        => new Vector2Int(Mathf.FloorToInt(WorldSpace.x / BoardTileSize), Mathf.FloorToInt(WorldSpace.x / BoardTileSize));

    public static Vector3 BoardSpaceToWorldSpace(Vector2Int BoardSpace) =>
        new Vector3(BoardSpace.x * BoardTileSize, BoardSpace.y * BoardTileSize);
    #endregion static functions
}
