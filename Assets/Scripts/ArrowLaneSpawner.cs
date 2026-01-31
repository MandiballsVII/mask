using UnityEngine;

public class ArrowLaneSpawner : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Color color;
    public lokingDirection lookingDirection;
    public Transform centralBox;

    public void SpawnArrow(float travelDuration)
    {
        GameObject arrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);

        arrow.GetComponent<SpriteRenderer>().color = color;
        arrow.transform.rotation = GetRotationFromDirection();
        arrow.layer = gameObject.layer;

        // Asignamos la dirección
        ArrowData data = arrow.AddComponent<ArrowData>();
        data.direction = lookingDirection;

        ArrowMovement movement = arrow.GetComponent<ArrowMovement>();
        movement.Init(travelDuration, centralBox.position.x);

        // Registramos esta arrow como la activa
        ArrowInputState.SetActiveArrow(data);
    }

    Quaternion GetRotationFromDirection()
    {
        return lookingDirection switch
        {
            lokingDirection.Left => Quaternion.Euler(0, 0, -90),
            lokingDirection.Up => Quaternion.Euler(0, 0, 180),
            lokingDirection.Right => Quaternion.Euler(0, 0, 90),
            _ => Quaternion.identity
        };
    }

}
public enum lokingDirection
{
    Left, Right, Up, Down
}
