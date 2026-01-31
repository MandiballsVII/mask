using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ButtonDetector1 : MonoBehaviour
{
    [Header("Input System")]
    public InputActionReference buttonAction;

    [Header("FX")]
    public GameObject hitFxPrefab;
    private Transform fxSpawnPoint;

    public List<GameObject> notasRango = new List<GameObject>();

    private SpriteRenderer spriteRenderer;

    public Sprite buttonUp;
    public Sprite buttonDown;

    private GameObject keyHitted;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        fxSpawnPoint = transform;
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

        if (notasRango.Count == 0)
            return;

        keyHitted = notasRango[0];

        SpawnHitFX();
        VerificarGolpe();
    }

    private void OnButtonReleased(InputAction.CallbackContext ctx)
    {
        spriteRenderer.sprite = buttonUp;
    }

    // ===== TRIGGERS =====

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Note") && !notasRango.Contains(other.gameObject))
        {
            notasRango.Add(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Note"))
        {
            notasRango.Remove(other.gameObject);
        }
    }

    // ===== FX =====

    private void SpawnHitFX()
    {
        if (hitFxPrefab == null)
            return;

        GameObject effect = Instantiate(hitFxPrefab, fxSpawnPoint.position, Quaternion.identity);
        Destroy(effect, 1f);
    }

    // ===== HIT LOGIC =====

    public void VerificarGolpe()
    {
        if (keyHitted == null)
            return;

        // Si ha llegado aquí, es HIT válido
        ScoreManager.instance?.AddScore(500);

        notasRango.Remove(keyHitted);
        Destroy(keyHitted);
        keyHitted = null;
    }
}
