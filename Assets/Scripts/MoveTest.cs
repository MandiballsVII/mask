using UnityEngine;
using UnityEngine.InputSystem;

public class MoveTest : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    private InputAction moveAction;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        // Acción de movimiento (Vector2)
        moveAction = new InputAction(
            name: "Move",
            type: InputActionType.Value,
            binding: "<Gamepad>/leftStick"
        );

        // Teclado WASD
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/w")
            .With("Down", "<Keyboard>/s")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        // Flechas
        moveAction.AddCompositeBinding("2DVector")
            .With("Up", "<Keyboard>/upArrow")
            .With("Down", "<Keyboard>/downArrow")
            .With("Left", "<Keyboard>/leftArrow")
            .With("Right", "<Keyboard>/rightArrow");
    }

    void OnEnable()
    {
        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
    }

    void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>().normalized;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveInput * moveSpeed;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        print("Player en trigger");
    }
}
