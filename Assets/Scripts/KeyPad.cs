using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public string correctCode = "1234567890"; // The correct code to unlock
    private string enteredCode = ""; // The code entered by the player

    private void Start()
    {
        // Optionally, you can initialize the enteredCode or set up any necessary references here
        enteredCode = "";
    }
    public void KeyPadButtonClicked(string buttonNumber)
    {
        //Debug.Log("Keypad button " + buttonNumber + " was clicked!");
        enteredCode += buttonNumber;
        Debug.Log ("Current entered code: " + enteredCode);
    }
}
