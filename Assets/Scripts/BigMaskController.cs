using UnityEngine;
using UnityEngine.Rendering.Universal;

public class BigMaskController : MonoBehaviour
{
    public Animator animator;

    private static readonly int EmotionParam = Animator.StringToHash("Emotion");
    private static readonly int GlitchTrigger = Animator.StringToHash("Glitch");

    public Light2D globalLight;
    public Light2D leftLight;
    public Light2D rightLight;
    public Light2D spotLight;

    public Color normalGlobalColor;
    public Color iraColor;
    public Color sadColor;
    public Color happyColor;
    public Color scareColor;

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
            lookingDirection.None => 4,   // Normal
            _ => 4
        };

        animator.SetInteger(EmotionParam, emotion);

        switch (emotion)
        {
            case 0: // Ira
                globalLight.color = iraColor;
                leftLight.color = iraColor;
                rightLight.color = iraColor;
                spotLight.color = iraColor;
                break;
            case 1: // Felicidad
                globalLight.color = happyColor;
                leftLight.color = happyColor;
                rightLight.color = happyColor;
                spotLight.color = happyColor;
                break;
            case 2: // Tristeza
                globalLight.color = sadColor;
                leftLight.color = sadColor;
                rightLight.color = sadColor;
                spotLight.color = sadColor;
                break;
            case 3: // Miedo
                globalLight.color = scareColor;
                leftLight.color = scareColor;
                rightLight.color = scareColor;
                spotLight.color = scareColor;
                break;
            case 4: //Normal
                globalLight.color = normalGlobalColor;
                leftLight.color = normalGlobalColor;
                rightLight.color = normalGlobalColor;
                spotLight.color = normalGlobalColor;
                break;
            default:
                globalLight.color = normalGlobalColor;
                leftLight.color = normalGlobalColor;
                rightLight.color = normalGlobalColor;
                spotLight.color = normalGlobalColor;
                break;
        }
    }

    void OnArrowDestroyed()
    {
        print("En arrow destroy: " + EmotionParam);
        animator.SetInteger(EmotionParam, 4);
        OnArrowChanged(lookingDirection.None);
    }
}
