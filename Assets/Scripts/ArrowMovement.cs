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
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger con: " + other.name);

        if (other.CompareTag("CentralBox"))
        {
            Debug.Log("CentralBox detectado");
            ArrowEvents.OnArrowDestroyed?.Invoke();
            Destroy(gameObject);
        }
    }
}
