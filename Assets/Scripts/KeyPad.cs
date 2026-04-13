using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public string correctCode = "1234567890"; // The correct code to unlock
    public void KeyPadButtonClicked(string buttonNumber)
    {
        Debug.Log("Keypad button " + buttonNumber + " was clicked!");
        // Add your logic here to handle the button click, such as checking if the correct code is entered.
    }
}
