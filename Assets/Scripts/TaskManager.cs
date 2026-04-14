//we could make tasks its own class/ struct to better track data. 
//its kind of grim that we have two arrays that are related yet not in code.
//But this works so lets just add +1 to the techincal debt (for prototyping this is fine)
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TaskManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI[] taskTexts;
    public bool[] taskFinished;
    public int fusesHeld = 0;
    public int pipesHeld = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskFinished = new bool[taskTexts.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void completeTask(int taskID)
    {
        if(!taskFinished[taskID]) 
        {
        taskTexts[taskID].color = Color.green;
        taskFinished[taskID] = true;
        }
    }

    public bool AreAllTaskFinshed()
    {
        foreach (var task in taskFinished)
        {
            if(task == false)
            {
                return false;
            }
        }
        return true;
    }

    public void increaseFuseCount()
    {
        fusesHeld++;
        taskTexts[1].text = "Task 1: Get Fuses " + fusesHeld + "/3";
        if (fusesHeld >= 3)
        {
            completeTask(1);
        }

    }

    public void increaseCoolingPipeCount()
    {
        pipesHeld++;
        taskTexts[4].text = "Task 5: Fix Cooling Pipes " + pipesHeld + "/3";
        if (pipesHeld >= 3)
        {
            completeTask(4);
        }

    }

    public bool checkCanShutDown()
    {
        for (int i = 0; i < taskTexts.Length - 1; i++)
        {
         if(taskFinished[i] == false)
            {
                return false;
            }
        }
        return true;
    }
}
