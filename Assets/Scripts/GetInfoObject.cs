using UnityEngine;

public class GetInfoObject : MonoBehaviour
{
    public string interactableTag = "Interactable";
    public float rayDistance = 100f;
    TaskManager taskManager;
    AdManager adManager;
    lightMananger lightMananger;
    [SerializeField] AudioSource interactAudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskManager = FindAnyObjectByType<TaskManager>();
        adManager = FindAnyObjectByType<AdManager>();
        lightMananger = FindAnyObjectByType<lightMananger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!adManager.isAdActive)
        {
            // 1. Listen for the click
            if (Input.GetMouseButtonDown(0))
            {
                PerformInteraction();
            }
        }
    }

    void PerformInteraction()
    {
        // 2. Create the Ray from the static camera to mouse position
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.green);

        // 3. Shoot the Ray
        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // 4. Check if the object has the "Interactable" tag
            if (hit.collider.CompareTag(interactableTag))
            {
                GameObject clickedObject = hit.collider.gameObject;

                 Debug.Log("Clicked on: " + clickedObject.name);
                 //game object detection logic we decide on will lbe done here like
                 switch (clickedObject.name)
                {
                    case "Fuse1":
                        taskManager.increaseFuseCount();
                        interactAudioSource.Play();
                        Destroy(clickedObject);
                        Debug.Log("Found Fuse");
                        break;
                    case "Fuse2":
                        taskManager.increaseFuseCount();
                        interactAudioSource.Play();
                        Destroy(clickedObject);
                        Debug.Log("Found Fuse");
                        break;
                    case "Fuse3":
                        taskManager.increaseFuseCount();
                        interactAudioSource.Play();
                        Destroy(clickedObject);
                        Debug.Log("Found Fuse");

                        break;
                    case "CircuitBreaker":
                        if (taskManager.fusesHeld == 3)
                        {
                            taskManager.completeTask(3);
                            lightMananger.turnLightsOn();
                        }
                        break;
                    case "KeyCard":   
                        taskManager.completeTask(2);
                        Debug.Log("Found KeyCard");
                        break;
                    case "DocumentTutorial":
                        taskManager.completeTask(0);
                        Debug.Log("Found Document");
                        break;
                    case "CoolingPipes1":
                        taskManager.increaseCoolingPipeCount();
                        interactAudioSource.Play();
                        Destroy(clickedObject);
                        Debug.Log("Found Coolant System");
                        break;
                    case "CoolingPipes2":
                        taskManager.increaseCoolingPipeCount();
                        interactAudioSource.Play();
                        Destroy(clickedObject);
                        Debug.Log("Found Coolant System");
                        break;
                    case "CoolingPipes3":
                        taskManager.increaseCoolingPipeCount();
                        interactAudioSource.Play();
                        Destroy(clickedObject);
                        Debug.Log("Found Coolant System");
                        break;
                    case "RodEngage":
                        taskManager.completeTask(6);
                        interactAudioSource.Play();
                        break;
                    case "ReactorButton":
                        if (taskManager.checkCanShutDown())
                        {
                            taskManager.completeTask(7);
                            interactAudioSource.Play();
                        }
                        break;
                }
            }
        }
    }

    void itemGrabbed(int ID, GameObject clickedObject)
    {
        taskManager.completeTask(ID);
        interactAudioSource.Play();
        Destroy(clickedObject);
       
    }

}
