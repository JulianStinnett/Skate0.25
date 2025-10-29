using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    private bool hasFinished = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasFinished) return;

        // Check that the object entering is your Player
        if (other.CompareTag("Player"))
        {
            hasFinished = true;
            SceneManager.LoadScene("StartMenu");
        }
    }
}