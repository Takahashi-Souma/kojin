using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    public float speed = 5f;

    // à⁄ìÆîÕàÕ
    public float minX = -8f;
    public float maxX = 8f;

    private Rigidbody rb;
    private Vector2 moveInput;
    private InputAction moveAction;

    void OnEnable()
    {
        moveAction = new InputAction(type: InputActionType.Value);
        moveAction.AddCompositeBinding("2DVector")
            .With("Left", "<Keyboard>/a")
            .With("Right", "<Keyboard>/d");

        moveAction.Enable();
    }

    void OnDisable()
    {
        moveAction.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        moveInput = moveAction.ReadValue<Vector2>();

        Vector3 move = new Vector3(moveInput.x, 0, 0);

        rb.linearVelocity = new Vector3(
            move.x * speed,
            rb.linearVelocity.y,
            0
        );

        // à íuêßå¿
        Vector3 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        transform.position = pos;
    }
}
