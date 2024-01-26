using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockHead : MonoBehaviour
{
    private Animator rockHeadAnimator;
    [SerializeField] private AudioSource LandSound;
    void Start()
    {
        rockHeadAnimator = GetComponent<Animator>();
        LandSound.volume = 10.0f;
    }
    
    private void OnTriggerEnter2D(Collider2D collider)
    {   
        PlayerLife player = collider.gameObject.GetComponent<PlayerLife>();
        if(collider.gameObject.name == "Player")
        {   
            player.Die();
        }
        
      
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            {
                rockHeadAnimator.SetTrigger("Land");
                LandSound.Play();
            }
    }
}
