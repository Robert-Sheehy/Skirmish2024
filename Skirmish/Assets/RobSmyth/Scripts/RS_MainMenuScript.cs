using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RS_MainMenuScript : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    public void QuitGame()
    {
        Debug.Log("Quit The Game");
        Application.Quit();
    }



    public void PauseGame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            SceneManager.LoadScene(0);
        }
    }
}
