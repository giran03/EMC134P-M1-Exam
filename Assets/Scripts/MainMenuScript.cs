using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            QuitCreditsDisplay();
        }
    }
    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void QuitGame()
    {
        Debug.Log("Application Exited");
        Application.Quit();
    }

    public void ChangeControls(bool toggle)
    {
        Debug.Log("Changed controler: " + toggle);
    }

    public void QuitCreditsDisplay()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
