using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] float speed = 40f;
    [SerializeField] float jumpForce = 20f;

    [Header("Kicking")]
    [SerializeField] Transform footPivot;
    [SerializeField] float footRotationSpeed = 20f;
    [SerializeField] float footMaxRotation = 140f;
    bool kickInput;

    [SerializeField] Kicker footKicker;

    [Header("Controls")]
    [SerializeField] KeyCode leftButton;
    [SerializeField] KeyCode rightButton;
    [SerializeField] KeyCode jumpButton;
    [SerializeField] KeyCode kickButton;

    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        kickInput = Input.GetKey(kickButton);
        footKicker.ApplyKick = kickInput;

        var moveInput = 0f;
        if (Input.GetKey(leftButton))
        {
            moveInput -= 1f;
        }
        if (Input.GetKey(rightButton))
        {
            moveInput += 1f;
        }
        rb.AddForce(new Vector2(moveInput * speed, 0f));
        HandleFootRotation();
        HandleJump();
    }

    void HandleJump()
    {
        if (Input.GetKey(jumpButton) && rb.velocity.y == 0f)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void HandleFootRotation()
    {
        var targetRotation = footPivot.transform.localEulerAngles.z + (footRotationSpeed * (kickInput ? 1f : -1f));
        footPivot.localEulerAngles = Vector3.forward * Mathf.Clamp(targetRotation, 0, footMaxRotation);
    }
}
