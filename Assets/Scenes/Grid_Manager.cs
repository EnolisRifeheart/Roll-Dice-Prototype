using UnityEngine;

public class Grid_Manager : MonoBehaviour
{

    // We are building am adjustable Grid System for a Roll Dice RPG game.

    public int width = 8;
    public int height = 8;

    public float tileSize = 1f;

    public Grid_Tiles tilePrefab; 

    private Grid_Tiles[,] gridArray;

    private void Start()
    {
        SpawnGrid();
    }

    private void SpawnGrid()
    {
        gridArray = new Grid_Tiles[width, height];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {

                Vector3 tilePosition = transform.position + new Vector3(x * tileSize, 0f, y * tileSize);

                Grid_Tiles newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity, transform);

                newTile.gridPosition = new Vector2Int(x, y);

                gridArray[x, y] = newTile;

                newTile.name = "Tile " + x + "," + y;
               
            }
        }
    }

    public Grid_Tiles GetTiles(int x, int y)
    {
        // We need to ensure that our requested tile exists inside the grid.

        if (x < 0 || x >= width || y < 0 || y >= height)
        {
            return null;
        }

        return gridArray[x, y];
    }

}


