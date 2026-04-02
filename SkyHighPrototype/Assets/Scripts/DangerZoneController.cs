using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;
    [SerializeField] private AudioSource warningAudioSource;

    private Coroutine activeCountdown;
    private Transform playerTransform;
    private bool isInZone = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
            playerTransform = other.transform;
            examManager.EnterDangerZone();

            if (warningAudioSource != null)
                warningAudioSource.Play();

            activeCountdown = StartCoroutine(MissileCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInZone)
        {
            isInZone = false;

            if (activeCountdown != null)
                StopCoroutine(activeCountdown);

            if (warningAudioSource != null)
                warningAudioSource.Stop();

            missileLauncher.DestroyActiveMissile();
            examManager.ExitDangerZone();
        }
    }

    public void OnMissileHit()
    {
        isInZone = false;

        if (activeCountdown != null)
            StopCoroutine(activeCountdown);

        missileLauncher.DestroyActiveMissile();
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        missileLauncher.Launch(playerTransform);
    }
}