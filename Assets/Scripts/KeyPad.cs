using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class KeyPad : MonoBehaviour
{
    public string correctCode = "123456"; // The correct code to unlock
    private string enteredCode = ""; // The code entered by the player
    public TMP_Text displayText; // Reference to the UI text element to display entered code (optional)
    public GameObject cancelButtonObject; // Reference to the 3D Cancel button
    public GameObject enterButtonObject; // Reference to the 3D Enter button

    //audio stuff is here below since thsi is independent form others if we want to move somewhere else we can later
    [SerializeField] AudioSource audioSource;
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
        if (enteredCode.Length >= 6)
        {
            Debug.Log("Code limit reached! Maximum 6 digits.");
            return; // Stop executing, don't add more digits
        }
        else
        {
            enteredCode += buttonNumber;
            audioSource.PlayOneShot(buttonPressClip); // Play button press sound
            if (displayText != null)
            {
                UpdateDisplay();
                displayText.text = enteredCode; // Update the display text with the current entered code
                // if (enteredCode.Length >= correctCode.Length)
                // {
                //     CheckCode();
                //     enteredCode = ""; // Reset the entered code after checking
                //             //Debug.Log ("Current entered code: " + enteredCode);
                // }
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
//////I have used some ai on the below parts of this code ot help me figure out how to implemen teh enter an dcancel button codes cause i coudlnt figure out a way myself without completly repurposing the code
    private void cancelButton()
    {
        // Cancel button (X) - removes the last digit entere
        if (enteredCode.Length > 0)
        {
            enteredCode = enteredCode.Substring(0, enteredCode.Length - 1); // Remove the last character
            audioSource.PlayOneShot(buttonPressClip); // Play button press sound
            UpdateDisplay(); // Update the display text after removing the last digit
        Debug.Log("Digit removed. Current code: " + enteredCode);
        }
        else
        {
            Debug.Log("Nothing to cancel.");
        }
    }

    private void EnterButton()
    {
        // Enter button (E) - submits the entered code for validation
        if (enteredCode.Length > 0)
        {
            Debug.Log("Enter pressed. Checking code: " + enteredCode);
            CheckCode();
            enteredCode = ""; // Reset the entered code after checking
            UpdateDisplay();
        }
        else
        {
            Debug.Log("Please enter a code first.");
        }
    }
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (cancelButtonObject != null && hit.collider.gameObject == cancelButtonObject)
                {
                    cancelButton();
                }
            
                if (enterButtonObject != null && hit.collider.gameObject == enterButtonObject)
                {
                    EnterButton();
                }
            }
        }
    }
}

