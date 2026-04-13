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
