using UnityEngine;
using UnityEngine.Events;

public class ButtonClicked : MonoBehaviour
{
    public int keyPadNumber;
    AdManager adManager;
    void Start()
    {
        adManager = FindAnyObjectByType<AdManager>();
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
