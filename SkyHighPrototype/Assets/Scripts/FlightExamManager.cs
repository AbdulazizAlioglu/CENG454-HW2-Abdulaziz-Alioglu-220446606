using UnityEngine;
using UnityEngine.UI;

public class FlightExamManager : MonoBehaviour
{
    [SerializeField] private Text statusText;
    [SerializeField] private Text missionText;

    private bool hasTakenOff = false;
    private bool threatCleared = false;
    private bool missionCompleted = false;

    public void EnterDangerZone()
    {
        statusText.text = "You have entered a danger zone! Be careful!";
        missionText.text = "Survive the danger zone and complete the landing!";
    }

    public void ExitDangerZone()
    {
        threatCleared = true;
        statusText.text = "";
        missionText.text = "Danger zone cleared! Now complete the landing!";
    }

    public void CompleteMission()
    {
        if (!threatCleared)
        {
            missionText.text = "You must clear the danger zone before completing the landing!";
            return;
        }

        missionCompleted = true;
        missionText.text = "Mission Completed! Well done!";
    }

    // 🔥 EKLEDİĞİM KISIMLAR
    public void PassExam()
    {
        CompleteMission(); // zaten kontrol burada var
    }

    public void FailExam()
    {
        statusText.text = "Crash Landing!";
        missionText.text = "Mission Failed! Landing too fast!";
        missionCompleted = false;
    }

    public bool IsThreatCleared() => threatCleared;

    public void OnMissileHit()
    {
        threatCleared = false;
        statusText.text = "You were hit! Try again!";
        missionText.text = "Re-enter the danger zone and escape!";
    }
}