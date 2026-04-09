using UnityEngine;

public class FlashLightControler : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

//flashlight brightness
    [SerializeField] float flashlightIntensity;

    //flash light max distance projection
    [SerializeField] float distance;

    // raycast for snapping light to the surfaces
    [SerializeField] bool useRaycast;

    /// flashlight surface mask for surfaces light should hit
    [SerializeField] LayerMask surfaceMask;

    void Start()
    {
        useRaycast = true;
        flashlightIntensity = 100f;
        distance = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        // 1. Get the current active camera
        Camera activeCam = Camera.main;
        if (activeCam == null) return;
        Debug.Log("Active Camera: " + activeCam.name);

        // 2. Determine target position based on mouse screen position
        Vector3 mousePos = Input.mousePosition;
        Vector3 worldPoint;
        Debug.Log("Mouse Position: " + mousePos);

        
    }
}
