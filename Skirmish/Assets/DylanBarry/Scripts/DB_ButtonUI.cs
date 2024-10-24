using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DB_ButtonUI : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "Level1";
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}

