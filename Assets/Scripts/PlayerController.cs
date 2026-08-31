using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float deceleration = 15f;
    [SerializeField] private GameObject shot;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = InputSystem.actions
            .FindAction("Move")
            .ReadValue<Vector2>();

        if (InputSystem.actions.FindAction("Attack").WasPressedThisFrame())
        {
            OnFire();
        }
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void OnFire()
    {
        Instantiate(shot, transform.position, Quaternion.identity);
    }

    private void Move()
    {
        Vector2 targetVelocity = moveInput * speed;

        float rate = moveInput.sqrMagnitude > 0
            ? acceleration
            : deceleration;

        rb.linearVelocity = Vector2.MoveTowards(
            rb.linearVelocity,
            targetVelocity,
            rate * Time.fixedDeltaTime
        );
    }
}