using UnityEngine;

public class LaneSpawner : MonoBehaviour
{
    public GameObject notePrefab;
    public Color color;
    public lokingDirection lookingDirection;

    private float timer;

    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 2f)
        {
            Spawn();
            timer = 0f;
        }
    }

    public void Spawn()
    {
        GameObject note = Instantiate(notePrefab, transform.position, Quaternion.identity);

        // Color
        note.GetComponent<SpriteRenderer>().color = color;

        // Rotación según dirección
        note.transform.rotation = GetRotationFromDirection();
    }

    Quaternion GetRotationFromDirection()
    {
        switch (lookingDirection)
        {
            case lokingDirection.Left:
                return Quaternion.Euler(0, 0, 90);

            case lokingDirection.Up:
                return Quaternion.Euler(0, 0, 180);

            case lokingDirection.Right:
                return Quaternion.Euler(0, 0, -90);

            case lokingDirection.Down:
            default:
                return Quaternion.identity;
        }
    }
}

public enum lokingDirection
{
    Left, Right, Up, Down
}
