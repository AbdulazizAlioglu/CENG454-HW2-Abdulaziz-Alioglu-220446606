using UnityEngine;

public class AircraftThreatHandler : MonoBehaviour
{
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private AudioSource hitAudioSource;
    [SerializeField] private FlightExamManager examManager;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Missile"))
        {
            if (hitAudioSource != null)
                hitAudioSource.Play();

            transform.position = respawnPoint.position;
            transform.rotation = respawnPoint.rotation;

            examManager.OnMissileHit();
        }
    }
}