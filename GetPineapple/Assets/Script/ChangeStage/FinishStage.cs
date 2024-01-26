using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishStage : MonoBehaviour
{
    private AudioSource FinnishSound;
    private bool isCompleted = false;
    void Start()
    {
        FinnishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player" && !isCompleted)
        {
            FinnishSound.Play();
            isCompleted = true;
            Invoke("CompleteLevel", 1f);
        }
    }

    private void CompleteLevel()
    {
        ItemCollector.pineapples = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
