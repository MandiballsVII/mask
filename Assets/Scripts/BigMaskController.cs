using UnityEngine;

public class BigMaskController : MonoBehaviour
{
    public Animator animator;

    // Mapeo explícito (fácil de leer y cambiar)
    private static readonly int EmotionParam = Animator.StringToHash("Emotion");

    void OnEnable()
    {
        ArrowEvents.OnArrowChanged += OnArrowChanged;
    }

    void OnDisable()
    {
        ArrowEvents.OnArrowChanged -= OnArrowChanged;
    }

    void OnArrowChanged(lookingDirection direction)
    {
        int emotion = direction switch
        {
            lookingDirection.Left => 0, // ira
            lookingDirection.Down => 1, // tristeza
            lookingDirection.Up => 2, // felicidad
            lookingDirection.Right => 3, // miedo
            _ => 4
        };

        animator.SetInteger(EmotionParam, emotion);
    }
}
