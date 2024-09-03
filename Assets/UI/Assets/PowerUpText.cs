using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PowerUpText : MonoBehaviour
{
    // Start is called before the first frame update
    public Button countButton;
    public Button reloadButton;
    public TextMeshProUGUI powerUpText; // Reference to the TextMeshPro UI Text component
    public TextMeshProUGUI reloadText;
    private int clickCount = 0;
    private int maxAmmo = 48;
    void Start()
    {
        powerUpText.text = $"{maxAmmo} / {maxAmmo}";
        if (countButton != null)
        {
            countButton.onClick.AddListener(OnButtonClick);
        }
        if (reloadButton != null)
        {
            reloadButton.onClick.AddListener(ReloadAmmo);
            reloadButton.gameObject.SetActive(false); // Hide the reload button initially
        }

        // Hide the reload message initially
        if (reloadText != null)
        {
            reloadText.gameObject.SetActive(false);
        }
    }
    /*void Update()
    {
        if (powerUpText != null)
        {
            // Count the number of GameObjects with the tag "PowerUp"
            int powerUpCount = GameObject.FindGameObjectsWithTag("PowerUp").Length;

            // Display the count in the TextMeshPro UI Text
            powerUpText.text = powerUpCount.ToString() + "/ 48";
        }
    }*/
    public void OnButtonClick()
    {
        clickCount++; // Increment the click count
        if (clickCount >= maxAmmo) // Ammo reaches 0
        {
            clickCount = maxAmmo; // Prevent count from exceeding max
            ShowReloadMessage();
        }

        UpdateClickCountText();// Update the text display
    }
    private void ShowReloadMessage()
    {
        if (reloadText != null)
        {
            reloadText.text = "RELOAD"; // Set reload message
            reloadText.gameObject.SetActive(true); // Show the reload message
        }

        if (reloadButton != null)
        {
            reloadButton.gameObject.SetActive(true);
            countButton.gameObject.SetActive(false); // Show the reload button
        }
    }
    public void ReloadAmmo()
    {
        clickCount = 0; // Reset the ammo count to full
        UpdateClickCountText(); // Update the display

        // Hide reload message and button
        if (reloadText != null)
        {
            reloadText.gameObject.SetActive(false);
        }

        if (reloadButton != null)
        {
            reloadButton.gameObject.SetActive(false);
            countButton.gameObject.SetActive(true);
        }
    }

    // Method to update the count display on the canvas
    public void UpdateClickCountText()
    {
        powerUpText.text = (48-clickCount).ToString() + " / 48";// Update the text with the current count
    }
}
