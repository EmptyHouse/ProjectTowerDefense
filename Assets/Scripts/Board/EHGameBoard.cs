using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct FBoardPosition
{
    public int X;
    public int Y;
    public bool Occupied;
}

public class EHGameBoard : MonoBehaviour
{
    public EHGameBoard ActiveGameBoard { get; private set; }
    public Vector2Int BoardSize = new Vector2Int(10, 10);
    private List<FBoardPosition> AllBoardTiles = new List<FBoardPosition>();

    #region monobehaviour methods

    private void Awake()
    {
        for (int i = 0; i < AllBoardTiles.Count; ++i)
        {
            FBoardPosition BoardPosition = new FBoardPosition();
            BoardPosition.X = i % BoardSize.x;
            BoardPosition.Y = i / BoardSize.x;
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
}
