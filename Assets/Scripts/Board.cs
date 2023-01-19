using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Board : MonoBehaviour
{
    public static int w = 10;
    public static int h = 20;
    public static GameObject[,] grid = new GameObject[w, h];

    // Rounds Vector2 so does not have decimal values
    // Used to force Integer coordinates (without decimals) when moving piecethiss
    public static Vector2 RoundVector2(Vector2 v)
    {
        return new Vector2(Mathf.Round(v.x),
                           Mathf.Round(v.y));
    }

    // TODO: Returns true if pos (x,y) is inside the grid, false otherwise
    public static bool InsideBorder(Vector2 pos)
    {
        return ((int)pos.x >= 0 &&
                (int)pos.x < w &&
                (int)pos.y >= 0);
    }

    // TODO: Deletes all GameObjects in the row Y and set the row cells to null.
    // You can use Destroy function to delete the GameObjects.
    public static void DeleteRow(int y)
    {
        for (int i = 0; i < w; i++)
        {
            grid[i, y].SetActive(false);
        }
    }

    // TODO: Moves all gameobject on row Y to row Y-1
    // 2 thing change:
    //  - All GameObjects on row Y go from cell (X,Y) to cell (X,Y-1)
    //  - Changes the GameObject transform position Gameobject.transform.position += new Vector3(0, -1, 0).
    public static void DecreaseRow(int y)
    {
        for (int i = 0; i < w; i++)
        {
            if (!grid[i, y].activeSelf)
            {
                grid[i, y].SetActive(grid[i, y - 1].activeSelf);
            }
        }
    }

    // TODO: Decreases all rows above Y
    public static void DecreaseRowsAbove(int y)
    {
        for (int i = y; i < h; i++)
        {
            DecreaseRow(i);
        }
    }

    // TODO: Return true if all cells in a row have a GameObject (are not null), false otherwise
    public static bool IsRowFull(int y)
    {
        for (int x = 0; x < w; ++x)
            if (grid[x, y].activeSelf)
                return false;
        return true;
    }

    // Deletes full rows
    public static void DeleteFullRows()
    {
        for (int y = 0; y < h; ++y)
        {
            if (IsRowFull(y))
            {
                DeleteRow(y);
                DecreaseRowsAbove(y + 1);
                --y;
            }
        }
    }


    public static void FillCells(GameObject block)
    {
        for (int i = 0; i < w; i++)
        {
            for (int j = 0; j < h; j++)
            {
                grid[i, j] = Instantiate(block, new Vector3(i, j, 0), Quaternion.identity);
                grid[i, j].SetActive(false);
            }
        }
    }
}
