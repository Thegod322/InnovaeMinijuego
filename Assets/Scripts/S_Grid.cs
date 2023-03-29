using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_Grid : MonoBehaviour
{


    [SerializeField] private GameObject tilePrefab;
    [SerializeField] public int numberOfCellsX;
    [SerializeField] public int numberOfCellsZ;
    [SerializeField] private float tileSize;

     public int startX;
     public int startY;
     public int EndX;
     public int EndY;
     public GameObject[,] grid;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        if (tilePrefab == null)
        {
            Debug.LogError("Tile prefab is not set in GridGenerator script.");
            return;
        }
        grid = new GameObject[numberOfCellsX, numberOfCellsZ];
        for (int x = 0; x < numberOfCellsX; x++)
        {
            for (int z = 0; z < numberOfCellsZ; z++)
            {
                GameObject tile = Instantiate(
                    tilePrefab,
                    new Vector3(transform.position.x + x * tileSize, transform.position.y, transform.position.z + z * tileSize),
                    Quaternion.identity,
                    transform
                );
                tile.transform.localScale = new Vector3(tileSize, tile.transform.localScale.y, tileSize);
                tile.name = $"Tile({x}, {z})";
                tile.AddComponent<S_Cell>();
                tile.GetComponent<S_Cell>().x = x;
                tile.GetComponent<S_Cell>().y = z;
                tile.GetComponent<S_Cell>().isWalkable = true;
                
            }
        }
    }

    void IniSetUp()
    {
        foreach (GameObject obj in grid)
        {
            obj.GetComponent<S_Cell>().visited = -1;
        }
        grid[startX, startY].GetComponent<S_Cell>().visited = 0;

    }

    bool TestDirection(int x, int y, int step, int direction)
    {
        switch (direction)
        {
            case 1:
                if (y + 1 < numberOfCellsZ && grid[x, y + 1] && grid[x, y + 1].GetComponent<S_Cell>().visited == step)
                    return true;
                else
                    return false;
            case 2:
                if (x + 1 < numberOfCellsX && grid[x + 1, y ] && grid[x + 1, y].GetComponent<S_Cell>().visited == step)
                    return true;
                else
                    return false;
            case 3:
                if (y - 1 > -1 && grid[x, y - 1] && grid[x, y - 1].GetComponent<S_Cell>().visited == step)
                    return true;
                else
                    return false;
            case 4:
                if (x - 1 > - 1 && grid[x - 1, y] && grid[x - 1, y].GetComponent<S_Cell>().visited == step)
                    return true;
                else
                    return false;

        }
        return false;
    }

    void SetVisited(int x, int y, int step)
    {
        if (grid[x,y])
        {
            grid[x, y].GetComponent<S_Cell>().visited = step;
        }
    }

    void SetDistance()
    {
        IniSetUp();
        int x = startX;
        int y = startY;
    }
}
