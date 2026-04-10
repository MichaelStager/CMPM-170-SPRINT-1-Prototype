using UnityEngine;

public class FlashLightControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    //flash light max distance projection
    [SerializeField] float rayDistance = 100f;

    // raycast for snapping light to the surfaces
    [SerializeField] bool useRaycast = true;

    /// flashlight surface mask for surfaces light should hit
    [SerializeField] LayerMask surfaceMask;

    void Start()
    {
       
        
        
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Get the current active camera and sanity check
        Camera activeCam = Camera.main;
        if (activeCam == null) return;
        //Debug.Log("Active Camera: " + activeCam.name);

        // 2. Determine target position based on mouse screen position and world depth
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPoint;
        //Debug.Log("Mouse Position: " + mousePos);

        if (useRaycast)
        {
            // Create a ray from camera through mouse position
            Ray ray = activeCam.ScreenPointToRay(mousePos);
            Debug.DrawRay(ray.origin, ray.direction * rayDistance, Color.red);
            if (Physics.Raycast(ray, out RaycastHit hit, rayDistance * 2, surfaceMask))
            {
                worldPoint = hit.point;
                //Debug.Log("Raycast Hit: " + worldPoint);
            }
            else
            {
                worldPoint = ray.GetPoint(rayDistance);
                //Debug.Log("Raycast Missed: " + worldPoint);
            }
        }
        else
        {
            // Simple depth-based position
            mousePos.z = rayDistance;
            worldPoint = activeCam.ScreenToWorldPoint(mousePos);
            //Debug.Log("Screen to World Point: " + worldPoint);
        }

        // 3. Update the Spotlight transform
        // You can either move the light itself or rotate it toward the point
        transform.LookAt(worldPoint);
        //Debug.Log("Light Direction: " + transform.forward);
    }
}
