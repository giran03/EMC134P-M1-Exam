using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameOverScript : MonoBehaviour
{
    public void RestartGame() {
        Debug.Log(StatsManagerScript.scoreCount);
        SceneManager.LoadScene("Game");
        StatsManagerScript.scoreCount = 0;
        StatsManagerScript.livesCount = 3;
    }

    public void ReturnToMainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
}
