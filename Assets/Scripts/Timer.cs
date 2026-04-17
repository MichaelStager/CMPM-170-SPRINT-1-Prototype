using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField]GameManager gamemanger;
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] string preTimerText = "TIME LEFT TILL MELTDOWN:";
    [SerializeField] Image timerImage;

// Update is called once per frame
    void Update()
    {
        updateTimerFill();
    }

    void updateTimerFill()
    {
        timerImage.fillAmount = gamemanger.currentTime / gamemanger.levelTime;
        timerImage.color = Color.Lerp(Color.red, Color.green,timerImage.fillAmount);
    }
}
