using UnityEngine;

public class NoteMovement : MonoBehaviour
{
    private float speed;

    public void Initialize(float distance, float travelTime)
    {
        speed = distance / travelTime;
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
