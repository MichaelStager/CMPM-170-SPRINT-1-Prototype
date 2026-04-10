using UnityEngine;

public class GetInfoObject : MonoBehaviour
{
    public string interactableTag = "Interactable";
    public float rayDistance = 100f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
                 if (clickedObject.name == "Fuse")
                {
                    // Just profff of concept for now
                    Debug.Log("Found Fuse");
                }
            }
        }
    }
}
