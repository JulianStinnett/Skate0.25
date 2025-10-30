using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    bool _restarting; // prevents multiple triggers while reloading

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_restarting) return; // skip if the restart process already started

        if (other.CompareTag("Player"))
        {
            _restarting = true;
            SimpleAudio.Instance?.PlayCrash(); // play crash sound
            Attempts.Increment();               // record another attempt
            StartCoroutine(ReloadAfterDelay(0.25f)); // wait a bit before restarting scene
        }
    }

    IEnumerator ReloadAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay); // wait for given seconds 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); // reload current scene
    }
}