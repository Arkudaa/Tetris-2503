using UnityEngine;

public class board : MonoBehaviour
{
    public int width = 10;
    public int height = 20;

    private Transform[,] grid;

    void Awake()
    {
        grid = new Transform[width, height];
    }

    Vector2Int WorldToCell(Vector3 worldPos)
    {
        Vector3 local = worldPos - transform.position;

        return new Vector2Int(
            Mathf.RoundToInt(local.x),
            Mathf.RoundToInt(local.y)
        );
    }

    public bool isValid(Transform piece)
    {
        foreach (Transform block in piece)
        {
            Vector2Int cell = WorldToCell(block.position);

            if (cell.x < 0 || cell.x >= width || cell.y < 0)
                return false;

            if (cell.y >= height)
                continue;

            if (grid[cell.x, cell.y] != null)
                return false;
        }

        return true;
    }

    public void Lock(Transform piece)
    {
        foreach (Transform block in piece)
        {
            Vector2Int cell = WorldToCell(block.position);

            if (cell.x < 0 || cell.x >= width || cell.y < 0 || cell.y >= height)
                continue;

            grid[cell.x, cell.y] = block;
        }
    }

    public void ClearLines()
    {
        for (int y = 0; y < height; y++)
        {
            if (IsLineFull(y))
            {
                DeleteLine(y);
                MoveLinesDown(y + 1);
                y--;
            }
        }
    }

    bool IsLineFull(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] == null)
                return false;
        }
        return true;
    }

    void DeleteLine(int y)
    {
        for (int x = 0; x < width; x++)
        {
            if (grid[x, y] != null)
            {
                Destroy(grid[x, y].gameObject);
                grid[x, y] = null;
            }
        }
    }

    void MoveLinesDown(int fromY)
    {
        for (int y = fromY; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                if (grid[x, y] != null)
                {
                    grid[x, y - 1] = grid[x, y];
                    grid[x, y] = null;
                    grid[x, y - 1].position += Vector3.down;
                }
            }
        }
    }
}