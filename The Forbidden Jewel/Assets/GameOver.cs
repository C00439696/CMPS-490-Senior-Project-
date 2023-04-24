using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public void TryAgain()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameOver.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level 1");
    }
}