using UnityEngine;

public class FlightController : MonoBehaviour
{
    [SerializeField] private float pitchSpeed = 45f;
    [SerializeField] private float yawSpeed = 45f;
    [SerializeField] private float rollSpeed = 45f;
    [SerializeField] private float thrustSpeed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        HandleRotation();
        HandleThrust();
    }

    private void HandleRotation()
    {
        float pitch = Input.GetAxis("Vertical") * pitchSpeed * Time.deltaTime;
        float yaw = Input.GetAxis("Horizontal") * yawSpeed * Time.deltaTime;

        transform.Rotate(Vector3.right * pitch);
        transform.Rotate(Vector3.up * yaw);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(-Vector3.forward * rollSpeed * Time.deltaTime);
        }
    }

    private void HandleThrust()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
        }
    }
}