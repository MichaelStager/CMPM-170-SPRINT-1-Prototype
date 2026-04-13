using UnityEngine;

public class KeyPad : MonoBehaviour
{
    public void KeyPadButtonClicked(int buttonNumber)
    {
        Debug.Log("Keypad button " + buttonNumber + " was clicked!");
        // Add your logic here to handle the button click, such as checking if the correct code is entered.
    }
}
