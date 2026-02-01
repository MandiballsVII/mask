using UnityEngine;

public class BigMaskController : MonoBehaviour
{
    public Animator animator;

    private static readonly int EmotionParam = Animator.StringToHash("Emotion");
    private static readonly int GlitchTrigger = Animator.StringToHash("Glitch");

    void OnEnable()
    {
        ArrowEvents.OnArrowChanged += OnArrowChanged;
        ArrowEvents.OnArrowDestroyed += OnArrowDestroyed;
    }

    void OnDisable()
    {
        ArrowEvents.OnArrowChanged -= OnArrowChanged;
        ArrowEvents.OnArrowDestroyed -= OnArrowDestroyed;
    }

    void OnArrowChanged(lookingDirection direction)
    {
        int emotion = direction switch
        {
            lookingDirection.Up => 0,     // Ira
            lookingDirection.Left => 1,   // Felicidad
            lookingDirection.Down => 2,   // Tristeza
            lookingDirection.Right => 3,  // Miedo
            _ => 0
        };

        animator.SetInteger(EmotionParam, emotion);
    }

    void OnArrowDestroyed()
    {
        animator.SetTrigger(GlitchTrigger);
    }
}
