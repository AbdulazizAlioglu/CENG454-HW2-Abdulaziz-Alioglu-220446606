using UnityEngine;

public class LandingZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private AudioSource landingAudioSource;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (landingAudioSource != null)
                landingAudioSource.Play();
                
            examManager.CompleteMission();
        }
    }
}