using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    private float speed;

    public void Init(float travelDuration, float targetX)
    {
        float distance = targetX - transform.position.x;
        speed = distance / travelDuration;
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime, Space.World);
    }
}
