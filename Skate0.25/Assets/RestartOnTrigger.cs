using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartOnTrigger : MonoBehaviour
{
    [SerializeField] string playerTag = "Player";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {

            SimpleAudio.Instance?.PlayCrash(); 
            Attempts.Increment();  
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}