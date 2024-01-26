using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void LoadStage(string stage)
    {
        SceneManager.LoadScene("Stage " + stage);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
