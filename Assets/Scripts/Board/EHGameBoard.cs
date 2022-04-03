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
}
