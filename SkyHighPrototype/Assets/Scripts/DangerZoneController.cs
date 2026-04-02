using UnityEngine;
using System.Collections;

public class DangerZoneController : MonoBehaviour
{
    [SerializeField] private FlightExamManager examManager;
    [SerializeField] private MissileLauncher missileLauncher;
    [SerializeField] private float missileDelay = 5f;

    private Coroutine activeCountdown;
    private Transform playerTransform;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTransform = other.transform;
            examManager.EnterDangerZone();
            activeCountdown = StartCoroutine(MissileCountdown());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (activeCountdown != null)
                StopCoroutine(activeCountdown);

            missileLauncher.DestroyActiveMissile();
            examManager.ExitDangerZone();
        }
    }

    private IEnumerator MissileCountdown()
    {
        yield return new WaitForSeconds(missileDelay);
        missileLauncher.Launch(playerTransform);
    }
}