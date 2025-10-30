using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AttemptsUI : MonoBehaviour
{
    public TMP_Text label;            // Reference to the TMP text component that displays the attempts
    public string prefix = "Attempts: "; // Optional text shown before the number

    void Awake()
    {
        // If no label is assigned in the Inspector, try to get one from this GameObject
        if (!label) label = GetComponent<TMP_Text>();

        Refresh(); // Update the label when the object is created
    }

    public void Refresh()
    {
        // Update the text to show the current attempt count
        if (label)
            label.text = prefix + Attempts.Current.ToString();
    }
}