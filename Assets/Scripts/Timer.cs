using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField]GameManager gamemanger;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] string preTimerText = "TIME LEFT TILL MELTDOWN:";
    int testNum = 1;
    int minutes;
    int seconds;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //gamemanger = FindAnyObjectByType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        decreaseTimerText();
    }


    void decreaseTimerText()
    {
        Debug.Log("UPDATIIIINGNGN!");
        // Clamp time so it doesn't go below zero if counting down
        minutes = Mathf.FloorToInt(gamemanger.currentTime / 60);
        seconds = Mathf.FloorToInt(((int)gamemanger.currentTime) % 60);

        // Format string to always show two digits (00:00)
        timerText.text =preTimerText + minutes.ToString() + ":" + seconds.ToString();
    }
}
