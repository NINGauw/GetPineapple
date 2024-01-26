using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{   
    private Rigidbody2D player;
    private Animator anim;

    [SerializeField] private AudioSource DeathSound;
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
    public void AddForce(Vector2 force)
    {
        player.AddForce(force);
    }
    public void Die()
    {   
        DeathSound.Play();
        player.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        ItemCollector.pineapples = 0;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
