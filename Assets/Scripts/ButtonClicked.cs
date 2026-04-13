using UnityEngine;
using UnityEngine.Events;

public class ButtonClicked : MonoBehaviour
{
    public int keyPadNumber;
    
    public UnityEvent onKeyPadButtonClicked;
    private void OnMouseDown()
    {
        Debug.Log("Button was clicked!");
        onKeyPadButtonClicked?.Invoke();
    }
}
/////JSUT PUT THEM HERE OT MODIFY MEY COD EAND SEE HWO THEY WORKED FOR DIABLING AND ENABLING CODE
    // public void disableButtons()
    // {
    //     foreach(var c in cameraButtons)
    //     {
    //         toggleButton.interactable = false;
    //         c.gameObject.GetComponent<Button>().interactable = false;
    //     }
    // }
    // public void enableButtons()
    // {
    //     foreach (var c in cameraButtons)
    //     {
    //         c.gameObject.GetComponent<Button>().interactable = true;
    //         toggleButton.interactable = true;
    //     }
    // }