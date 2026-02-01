using UnityEngine;

public class ArrowLaneSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Color color;
    public lookingDirection lookingDirection;
    public Transform centralBox;

    public void SpawnArrow(float travelDuration)
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        SpriteRenderer sr = arrow.GetComponent<SpriteRenderer>();
        sr.color = GetColorFromDirection();

        arrow.transform.rotation = GetRotationFromDirection();
        arrow.layer = gameObject.layer;

        // Dirección
        ArrowData data = arrow.AddComponent<ArrowData>();
        data.direction = lookingDirection;

        ArrowMovement movement = arrow.GetComponent<ArrowMovement>();
        movement.Init(travelDuration, centralBox.position.x);

        ArrowInputState.SetActiveArrow(data);
    }

    Quaternion GetRotationFromDirection()
    {
        return lookingDirection switch
        {
            lookingDirection.Left => Quaternion.Euler(0, 0, -90),
            lookingDirection.Up => Quaternion.Euler(0, 0, 180),
            lookingDirection.Right => Quaternion.Euler(0, 0, 90),
            _ => Quaternion.identity
        };
    }
    Color GetColorFromDirection()
    {
        return lookingDirection switch
        {
            lookingDirection.Left => Color.red,
            lookingDirection.Up => Color.yellow,
            lookingDirection.Right => Color.magenta,
            lookingDirection.Down => Color.blue,
            _ => Color.white
        };
    }

}
public enum lookingDirection
{
    Left, Right, Up, Down
}
