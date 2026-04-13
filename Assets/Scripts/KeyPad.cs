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
        //Debug.Log ("Current entered code: " + enteredCode);
        if (enteredCode.Length >= correctCode.Length)
        {
            CheckCode();
            enteredCode = ""; // Reset the entered code after checking
        }
    }

    private void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            Debug.Log("Correct code entered! Door unlocked.");
            // notes for me Add logic here to unlock the door or trigger the next event 
            // and also to make sure to connect with task list stuff
            //add audio as well for correct code entry 
        }
        else
        {
            Debug.Log("Incorrect code. Try again.");
            // add audio cue for incorrect code entry and maybe a visual cue as well 
            // (like shaking the keypad or changing the color of the text) etc
        }
    }
}
