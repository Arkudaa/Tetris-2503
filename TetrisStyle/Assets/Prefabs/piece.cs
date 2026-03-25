using UnityEngine;
using System.Collections;

public class piece : MonoBehaviour
{
    public board board;
    public spawner spawner;

    public float fallTime = 0.8f;
    public float fastFallTime = 0.05f;

    private float timer = 0f;
    private bool locked = false;

    void Start()
    {
        SnapToGrid();
    }

    void Update()
    {
        if (locked) return;
        if (board == null || spawner == null) return;

        timer += Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            Move(Vector3.left);

        if (Input.GetKeyDown(KeyCode.RightArrow))
            Move(Vector3.right);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            RotatePiece();

        float currentFallTime = Input.GetKey(KeyCode.DownArrow) ? fastFallTime : fallTime;

        if (timer >= currentFallTime)
        {
            timer = 0f;
            Fall();
        }
    }

    void Fall()
    {
        transform.position += Vector3.down;
        SnapToGrid();

        if (!board.isValid(transform))
        {
            transform.position += Vector3.up;
            SnapToGrid();

            board.Lock(transform);
            board.ClearLines();

            locked = true;
            enabled = false;
            StartCoroutine(SpawnNext());
        }
    }

    IEnumerator SpawnNext()
    {
        yield return null;
        if (spawner != null)
            spawner.Spawn();
    }

    void Move(Vector3 dir)
    {
        transform.position += dir;
        SnapToGrid();

        if (!board.isValid(transform))
        {
            transform.position -= dir;
            SnapToGrid();
        }
    }

    void RotatePiece()
    {
        transform.Rotate(0f, 0f, -90f);
        SnapToGrid();

        if (!board.isValid(transform))
        {
            transform.Rotate(0f, 0f, 90f);
            SnapToGrid();
        }
    }

    void SnapToGrid()
    {
        transform.position = new Vector3(
            Mathf.Round(transform.position.x),
            Mathf.Round(transform.position.y),
            0f
        );

        foreach (Transform block in transform)
        {
            block.position = new Vector3(
                Mathf.Round(block.position.x),
                Mathf.Round(block.position.y),
                0f
            );
        }
    }
}