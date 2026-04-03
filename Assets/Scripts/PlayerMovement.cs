using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [Header("Settings")]
    public float moveSpeed = 5f;

    [Header("Input Setup")]
    public InputActionReference moveActionRef;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnEnable()
    {
        moveActionRef.action.Enable();
    }

    void OnDisable()
    {
        moveActionRef.action.Disable();
    }

    void Update()
    {
        moveInput = moveActionRef.action.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rb.position + moveInput * moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(newPosition);
    }
}