using UnityEngine;
using TMPro;
using Unity.Cinemachine;
public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineCamera[] cameras;
    private CinemachineCamera currentCamera;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //CurrentCamera is set to the first camera in the array.
    void Start()
    {
        currentCamera = cameras[0];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SwitchCamera(int index)
    {
        if (index < 0 || index >= cameras.Length)
        {
            Debug.LogError("Invalid camera index: " + index);
            return;
        }
        if (currentCamera != null)
        {
            currentCamera.gameObject.SetActive(false);
        }
        currentCamera = cameras[index];
        currentCamera.gameObject.SetActive(true);
    }
}
