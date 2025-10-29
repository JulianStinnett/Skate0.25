using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        // Replace "GameScene" with the name of your main gameplay scene
        SceneManager.LoadScene("Main");
    }
}