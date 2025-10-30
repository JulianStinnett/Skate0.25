using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private bool hasFinished = false; // Prevents the finish logic from triggering more than once

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasFinished) return; // Ignore if already triggered once

        // Only trigger when the player reaches the finish line
        if (other.CompareTag("Player"))
        {
            hasFinished = true;
            // Load the Start Menu scene when the player finishes the level
            SceneManager.LoadScene("StartMenu");
        }
    }
}