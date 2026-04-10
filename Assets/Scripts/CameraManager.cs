using UnityEngine;
using TMPro;
using Unity.Cinemachine;
using UnityEngine.UI;
public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineCamera[] cameras;
    [SerializeField] GameObject[] cameraButtons;
    [SerializeField] Button toggleButton;
    private CinemachineCamera currentCamera;
    private GameObject currentButton;
    bool isCamOverlayActive = true;
    GameObject mapImage;
    AdManager adManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    //CurrentCamera is set to the first camera in the array.
    void Start()
    {
        adManager = FindAnyObjectByType<AdManager>();
        mapImage = GameObject.FindWithTag("map");
        currentCamera = cameras[0];
        currentButton = cameraButtons[0];
        currentButton.GetComponent<Image>().color = Color.green;
    }

    private void Update()
    {
        if (adManager.isAdActive)
        {
            disableButtons();
        }
        else if (!adManager.isAdActive)
        {
            enableButtons();
        }
    }

    //This function is called to switch the current camera to the camera at the specified index, it also changes the color of the button to green to give feedback on where you are. This is called through the onlcick() function of the buttons in the UI.
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
            currentButton.GetComponent<Image>().color = Color.white; // Reset the color of the previous button to white
        }
        currentCamera = cameras[index];
        currentCamera.gameObject.SetActive(true);
        currentButton = cameraButtons[index];
        currentButton.GetComponent<Image>().color = Color.green; // Set the color of the current button to green to indicate it's active
    }

    //this function will be called by the hide button, this will be so that the player can hide the cam select overlay.
    public void toggleSCamOverlay()
    {
        if (isCamOverlayActive)
        {
            foreach (var b in cameraButtons)
            {
                b.gameObject.SetActive(false);
            }
            mapImage.SetActive(false);
            isCamOverlayActive = false;
        }
        else
        {
            foreach (var b in cameraButtons)
            {
                b.gameObject.SetActive(true);
            }
            mapImage.SetActive(true);
            isCamOverlayActive = true;
        }
    }

    public void disableButtons()
    {
        foreach(var c in cameraButtons)
        {
            toggleButton.interactable = false;
            c.gameObject.GetComponent<Button>().interactable = false;
        }
    }
    public void enableButtons()
    {
        foreach (var c in cameraButtons)
        {
            c.gameObject.GetComponent<Button>().interactable = true;
            toggleButton.interactable = true;
        }
    }


}
