using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private AudioClip pauseSound;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
             //Kiểm tra xem game có đang pause không, nếu có thì dừng pause
            if(pauseScreen.activeInHierarchy)
            PauseGame(false);
            else
            PauseGame(true);
        }
    }

    private void PauseGame(bool status)
    {
        pauseScreen.SetActive(status);
        Time.timeScale = status ? 0 : 1;
    }

    public void RestartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Tải lại màn hiện tại
    }

    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Start"); // Thay đổi "MenuSceneName" bằng tên cảnh menu của bạn
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}