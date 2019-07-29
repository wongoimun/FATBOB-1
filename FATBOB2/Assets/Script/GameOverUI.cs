using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public GameManager GameM;

    public void Quit()
    {
        Debug.Log("Game has Quit");
        Application.Quit();
    }

    public void Retry()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        GameM.Restart();
        SceneManager.LoadScene("backup21");
        
    }
}
