using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KillZone : MonoBehaviour
{
    bool _restarting;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_restarting) return;
        if (other.CompareTag("Player"))
        {
            _restarting = true;
            SimpleAudio.Instance?.PlayCrash();
            Attempts.Increment();
            StartCoroutine(ReloadAfterDelay(0.25f)); // give sound time to play
        }
    }

    System.Collections.IEnumerator ReloadAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}