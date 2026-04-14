using UnityEngine;
using UnityEngine.Events;

public class ButtonClicked : MonoBehaviour
{
    public int keyPadNumber;
    AdManager adManager;
    KeyPad keyPad;
    void Start()
    {
        adManager = FindAnyObjectByType<AdManager>();
        keyPad = FindAnyObjectByType<KeyPad>();
    }
    
    public UnityEvent onKeyPadButtonClicked;
    private void OnMouseDown()
    {
        
        if (!adManager.isAdActive)
        {
            Debug.Log("Button was clicked!");
            onKeyPadButtonClicked?.Invoke();
        }
    }
}
