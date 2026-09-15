using UnityEngine;

public class Player : MonoBehaviour
{
    public Grid_Manager grid;

    public Grid_Tiles currentTile;

    public int movementRange = 1;

    public bool canMove = false;

    private void Start()
    {
        SetStartingTile();
    }


    private void Update()
    {
        DetectTile();
    }

    private void MoveToSelectedTile(Grid_Tiles targetTile)
    {
        currentTile.isOccupied = false;

        currentTile = targetTile;

        currentTile.isOccupied = true;

        transform.position = currentTile.transform.position;


        // Lock movement to prevent not going past the rolled die.
        canMove = false;
        movementRange = 0;
    }

    private void CheckMovement(Grid_Tiles targetTile)
    {
        Vector2Int currentPosition = currentTile.gridPosition;
        Vector2Int targetPosition = targetTile.gridPosition;

        int xDistance = Mathf.Abs(targetPosition.x - currentPosition.x);
        int yDistance = Mathf.Abs(targetPosition.y - currentPosition.y);

        int distance = Mathf.Max(xDistance, yDistance);

        if (distance > movementRange)
        {
            Debug.Log("Tile far away.");
            return;
        }

        if (!targetTile.isWalkable || targetTile.isOccupied)
        {
            Debug.Log("Caannot move onto tile.");
            return;
        }

        MoveToSelectedTile(targetTile);
    }

    private void DetectTile()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 

        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Grid_Tiles selectedTile = hit.collider.GetComponent<Grid_Tiles>();

            if (selectedTile == null)
            {
                return;
            }

            CheckMovement(selectedTile);
        }
    }

    private void SetStartingTile()
    {
        currentTile = grid.GetTiles(0, 0);

        if (currentTile == null)
        {
            return;
        }

        transform.position = currentTile.transform.position;

        currentTile.isOccupied = true;
    }
}
