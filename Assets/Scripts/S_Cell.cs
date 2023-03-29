using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Cell : MonoBehaviour
{
    public int x;
    public int y;
    public bool isWalkable;
    public int visited = 1;
    public int gCost;
    public int hCost;
    public S_Cell parent;
}
