using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] taskTexts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void completeTask(int taskID)
    {
        taskTexts[taskID].color = Color.green;
    }
}
