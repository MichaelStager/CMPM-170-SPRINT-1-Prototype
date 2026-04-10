using UnityEngine;

public class GetInfoObject : MonoBehaviour
{
    public string interactableTag = "Interactable";
    public float rayDistance = 100f;
    TaskManager taskManager;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        taskManager = FindAnyObjectByType<TaskManager>();
    }

    // Update is called once per frame
    void Update()
    {
// 1. Listen for the click
        if (Input.GetMouseButtonDown(0))
        {
            PerformInteraction();
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
                        taskManager.completeTask(0);
                        Destroy(clickedObject);
                        Debug.Log("Found Fuse");
                        break;
                    case "Fuse2":
                        taskManager.completeTask(1);
                        Destroy(clickedObject);
                        Debug.Log("Found Fuse2");
                        break;
                    case "Fuse3":
                        Debug.Log("Found Fuse3");
                        break;
                    case "fix the circuit breaker":
                        Debug.Log("Found Circuit Breaker");
                        break;
                    case "battery" :
                        Debug.Log("Found Battery");
                        break;
                    case "flip electricity switch":
                        Debug.Log("Found Electricity Switch");
                        break;
                    case "read document":
                        Debug.Log("Found Document");
                        break;
                    case "re activate the coolant system":
                        Debug.Log("Found Coolant System");
                        break;
                    
                }
            }
        }
    }
}
