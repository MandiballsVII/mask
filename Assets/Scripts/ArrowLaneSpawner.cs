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

        // USAR el ArrowData del prefab
        ArrowData data = arrow.GetComponent<ArrowData>();
        data.direction = lookingDirection;

        ArrowMovement movement = arrow.GetComponent<ArrowMovement>();
        Collider2D boxCollider = centralBox.GetComponent<Collider2D>();

        float destroyX = boxCollider.bounds.min.x - 0.5f;
        // borde izquierdo REAL del trigger en world units

        movement.Init(travelDuration, destroyX);

        ArrowInputState.SetActiveArrow(data);

        ArrowInputState.SetActiveArrow(data);

        // Avisamos al mundo
        ArrowEvents.OnArrowChanged?.Invoke(lookingDirection);
        print("Final de Arrow Spawn");
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
            lookingDirection.Up => Color.red,        // Ira
            lookingDirection.Left => Color.yellow,   // Felicidad
            lookingDirection.Down => Color.blue,     // Tristeza
            lookingDirection.Right => Color.magenta, // Miedo
            _ => Color.white
        };
    }


}
public enum lookingDirection
{
    Left, Right, Up, Down
}
