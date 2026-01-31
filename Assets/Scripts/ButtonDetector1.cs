using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonDetector1 : MonoBehaviour
{
    [Header("Input System")]
    public InputActionReference buttonAction;

    [Header("FX")]
    public GameObject hitFxPrefab;

    [Header("Visual")]
    public Sprite buttonUp;
    public Sprite buttonDown;

    private SpriteRenderer spriteRenderer;

    // NOTAS DENTRO DEL TRIGGER (única fuente de verdad)
    private readonly List<GameObject> notasEnTrigger = new();

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnEnable()
    {
        buttonAction.action.Enable();
        buttonAction.action.performed += OnButtonPressed;
        buttonAction.action.canceled += OnButtonReleased;
    }

    private void OnDisable()
    {
        buttonAction.action.performed -= OnButtonPressed;
        buttonAction.action.canceled -= OnButtonReleased;
        buttonAction.action.Disable();
    }

    // ===== INPUT =====

    private void OnButtonPressed(InputAction.CallbackContext ctx)
    {
        spriteRenderer.sprite = buttonDown;

        // ❌ No hay nota → MISS
        if (notasEnTrigger.Count == 0)
        {
            ScoreManager.instance?.ResetCombo();
            return;
        }

        // ✅ HIT → usamos la primera nota válida
        GameObject note = notasEnTrigger[0];

        SpawnHitFX();
        ScoreManager.instance?.AddScore(500);

        notasEnTrigger.Remove(note);
        Destroy(note);
    }

    private void OnButtonReleased(InputAction.CallbackContext ctx)
    {
        spriteRenderer.sprite = buttonUp;
    }

    // ===== TRIGGERS =====

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Note"))
            return;

        if (!notasEnTrigger.Contains(other.gameObject))
            notasEnTrigger.Add(other.gameObject);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (!other.CompareTag("Note"))
            return;

        notasEnTrigger.Remove(other.gameObject);
    }

    // ===== FX =====

    private void SpawnHitFX()
    {
        if (hitFxPrefab == null)
            return;

        GameObject fx = Instantiate(hitFxPrefab, transform.position, Quaternion.identity);
        Destroy(fx, 1f);
    }
}
