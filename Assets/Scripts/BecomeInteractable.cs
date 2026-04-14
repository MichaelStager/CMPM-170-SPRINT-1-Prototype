using UnityEngine;

public class BecomeInteractable : MonoBehaviour
{
    TaskManager taskManager;
    [SerializeField] int taskID;
   
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskManager = FindAnyObjectByType<TaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (taskManager.taskFinished[taskID] && gameObject.tag != "Interactable")
        {
            becomeInteractable();
        }
    }

    void becomeInteractable()
    {
        gameObject.tag = "Interactable";
    }
}
