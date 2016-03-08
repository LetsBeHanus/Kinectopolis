using UnityEngine;
using System.Collections;

public class MazeGenerator : MonoBehaviour {

    public GameObject mazeTile;
    public GameObject player;
    private float triSide = 20.0f * Mathf.Sin(0.785f);
    private float currentLevel = 40.0f;
    private float currentX = -10.0f;
    private int count = 0;
    private int score;
    private enum Direction
    {
        left,
        right,
        up
    }
    private Direction last;

    // Use this for initialization
    void Start () {
        Instantiate(mazeTile, new Vector3(currentX + triSide/2, currentLevel, 0.0f), Quaternion.Euler(0.0f, 0.0f, 45.0f));
        Instantiate(mazeTile, new Vector3(currentX + 20.0f + triSide/2, currentLevel, 0.0f), Quaternion.Euler(0.0f, 0.0f, 45.0f));
        currentX += triSide / 2;
        last = Direction.right;
    }
	
	// Update is called once per frame
	void Update () {
        if (player.transform.position.y > currentLevel - 50.0f)
        {
            int rand = Random.Range(1, 4);
            if (rand == 1)
            {
                // Maze goes right
                if (last == Direction.right)
                {
                    //Maze went same way last time to move tile to the right
                    currentX += triSide;
                    currentLevel += triSide;
                }
                else if (last == Direction.up)
                {
                    // Maze went up last so move tile to the right
                    currentX += triSide / 2;
                    currentLevel += triSide / 2 + 10.0f;
                }
                else if (last == Direction.left)
                {
                    // Maze went left last so move tile up but keep on same x
                    currentLevel += triSide;
                }

                // Place maze tiles
                Instantiate(mazeTile, new Vector3(currentX, currentLevel, 0.0f), Quaternion.Euler(0.0f, 0.0f, 45.0f));
                Instantiate(mazeTile, new Vector3(currentX + 20.0f, currentLevel, 0.0f), Quaternion.Euler(0.0f, 0.0f, 45.0f));
                count++;

                // Save direction for next maze piece
                last = Direction.right;
            }
            else if (rand == 2)
            {
                // Maze goes left
                if (last == Direction.left)
                {
                    // Move tile to the left and up
                    currentLevel += triSide;
                    currentX -= triSide;
                }
                else if (last == Direction.up)
                {
                    // Move tile to the left half and up half
                    currentLevel += triSide / 2 + 10.0f;
                    currentX -= triSide / 2;
                }
                else if (last == Direction.right)
                {
                    // Move tile up but keep the same x position
                    currentLevel += triSide;
                }

                // Place maze tiles
                Instantiate(mazeTile, new Vector3(currentX, currentLevel, 0.0f), Quaternion.Euler(0.0f, 0.0f, -45.0f));
                Instantiate(mazeTile, new Vector3(currentX + 20.0f, currentLevel, 0.0f), Quaternion.Euler(0.0f, 0.0f, -45.0f));
                count++;

                // Save direction for next maze piece
                last = Direction.left;
            }
            else
            {
                // Maze goes up
                if (last == Direction.right)
                {
                    // Maze was right so add half x and half of angle x and half of vertical x
                    currentX += triSide / 2;
                    currentLevel += triSide / 2 + 10.0f;
                }
                else if (last == Direction.left)
                {
                    // Maze was left so subtract half x and level goes up half of angle x and half of width
                    currentX -= triSide / 2;
                    currentLevel += triSide / 2 + 10.0f;
                }
                else if (last == Direction.up)
                {
                    // Maze keeps x position and level goes up width of tile
                    currentLevel += 20.0f;
                }

                // Place maze tiles
                Instantiate(mazeTile, new Vector3(currentX, currentLevel, 0.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f));
                Instantiate(mazeTile, new Vector3(currentX + 20.0f, currentLevel, 0.0f), Quaternion.Euler(0.0f, 0.0f, 90.0f));
                count++;

                // Store direction for next tile
                last = Direction.up;
            }
        }
    }
}
