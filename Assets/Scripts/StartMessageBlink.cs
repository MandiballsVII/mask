using UnityEngine;
using TMPro;

public class StartMessageBlink : MonoBehaviour
{
    public float blinkSpeed = 2f;

    CanvasGroup canvasGroup;
    float timer;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();

        // si no existe lo añadimos automáticamente
        if (canvasGroup == null)
            canvasGroup = gameObject.AddComponent<CanvasGroup>();
    }

    void OnEnable()
    {
        timer = 0f;
        canvasGroup.alpha = 1f;
    }

    void Update()
    {
        timer += Time.deltaTime * blinkSpeed;

        // efecto fade in/out suave (más arcade que encender/apagar)
        canvasGroup.alpha = Mathf.Abs(Mathf.Sin(timer));
    }
}
