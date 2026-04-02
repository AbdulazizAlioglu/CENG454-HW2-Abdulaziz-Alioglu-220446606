using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private AudioSource landingAudioSource;
    [SerializeField] private float maxLandingSpeed = 10f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                float speed = rb.linearVelocity.magnitude;

                if (speed <= maxLandingSpeed)
                {
                    Debug.Log("Successful Landing!");

                    if (landingAudioSource != null)
                        landingAudioSource.Play();

                    examManager.PassExam();
                }
                else
                {
                    Debug.Log("Crash Landing!");
                    examManager.FailExam();
                }
            }
        }
    }
}