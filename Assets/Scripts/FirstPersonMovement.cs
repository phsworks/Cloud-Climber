using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float _speed = 5f;
    public float _jumpForce = 8f;
    private Rigidbody rb;
    private bool isGrounded;
    public float gravityMultiplier = 2.5f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GameObject.Find("Player").GetComponent<Rigidbody>();
        transform.position = new Vector3(3.75f, 63.24f, -15.17f);

    }

    // Update is called once per frame
    void Update()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (gravityMultiplier - 1) * Time.deltaTime;
        }

        float HorizontalInput = Input.GetAxis("Horizontal");
        float VerticalInput = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.right * HorizontalInput + transform.forward * VerticalInput;
        Vector3 velocity = moveDirection * _speed;
        rb.linearVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Ground") || other.gameObject.CompareTag("Platform"))
        {
            isGrounded = true;
        }
    }
}
