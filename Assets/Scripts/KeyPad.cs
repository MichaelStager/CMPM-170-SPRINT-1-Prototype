using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class KeyPad : MonoBehaviour
{
    public string correctCode = "1234567890"; // The correct code to unlock
    private string enteredCode = ""; // The code entered by the player
    public TMP_Text displayText; // Reference to the UI text element to display entered code (optional)

    //audio stuff is here below since thsi is independent form others if we want to move somewhere else we can later
    AudioSource audioSource;
    [SerializeField] AudioClip buttonPressClip;
    [SerializeField] AudioClip correctCodeClip;
    [SerializeField] AudioClip incorrectCodeClip;

    private void Start()
    {
        // Optionally, you can initialize the enteredCode or set up any necessary references here
        enteredCode = "";
    }
    public void KeyPadButtonClicked(string buttonNumber)
    {
        //Debug.Log("Keypad button " + buttonNumber + " was clicked!");
        enteredCode += buttonNumber;
        audioSource.PlayOneShot(buttonPressClip); // Play button press sound
        if (displayText != null)
        {
            UpdateDisplay();
            displayText.text = enteredCode; // Update the display text with the current entered code
            if (enteredCode.Length >= correctCode.Length)
            {
                CheckCode();
                enteredCode = ""; // Reset the entered code after checking
                        //Debug.Log ("Current entered code: " + enteredCode);
            }
        }

    }

    void UpdateDisplay()
    {
        if (displayText != null) displayText.text = enteredCode;
    }

    private void CheckCode()
    {
        if (enteredCode == correctCode)
        {
            Debug.Log("Correct code entered! Door unlocked.");
            // notes for me Add logic here to unlock the door or trigger the next event 
            // and also to make sure to connect with task list stuff
            audioSource.PlayOneShot(correctCodeClip); // Play correct code sound
        }
        else
        {
            Debug.Log("Incorrect code. Try again.");
            
            // (like shaking the keypad or changing the color of the text) etc
            audioSource.PlayOneShot(incorrectCodeClip); // Play incorrect code sound
        }
    }
}
//added teh auidio cues