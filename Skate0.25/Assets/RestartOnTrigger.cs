using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartOnTrigger : MonoBehaviour
{
    [SerializeField] string playerTag = "Player"; // Tag used to identify the player

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the trigger is the player
        if (other.CompareTag("Player"))
        {
            SimpleAudio.Instance?.PlayCrash(); // play crash sound
            Attempts.Increment();               // record a failed attempt
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload the current scene
        }
    }
}