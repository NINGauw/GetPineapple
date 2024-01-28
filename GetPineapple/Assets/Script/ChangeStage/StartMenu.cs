using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartMenu : MonoBehaviour
{
    public void To1PMenu()
    {
        SceneManager.LoadScene("ChooseStage");
    }
    public void BacktoStart()
    {
        SceneManager.LoadScene("Start");
    }
    public void LoadStage(string stage)
    {
        SceneManager.LoadScene("Stage " + stage);
    }
    public void LoadScene2P(string stage)
    {
        SceneManager.LoadScene("Stage2P " + stage);
    }
    public void ToScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
    public void To2PMenu()
    {
        SceneManager.LoadScene("Choose2P");
    }
    public void QuitGame()
    {
        Application.Quit();
    }
}
