using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;


public class GhostAI : MonoBehaviour
{
    private int currentWaypointIndex = 0;
    private Vector3 originalScale;
    [SerializeField] private float speed = 2f; 
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private AudioSource GhostTouchSound;
    private void Start()
    {
        originalScale = transform.localScale; // Lưu scale ban đầu   
    }
    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
            Flip();
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
    private void Flip()
    {
        // Flip object bằng cách đảo ngược dấu của x trong localScale
        transform.localScale = new Vector3(-transform.localScale.x, originalScale.y, originalScale.z);
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        Rigidbody2D player = collider.gameObject.GetComponent<Rigidbody2D>();
        PlayerLife playerlife =  collider.gameObject.GetComponent<PlayerLife>();
        if(collider.gameObject.CompareTag("Player"))
        {
            if(player.gravityScale >= 80)
            {
                playerlife.Die();
            }
            GhostTouchSound.Play();
           player.gravityScale *= 2f;
        }
        if(collider.gameObject.CompareTag("RemoveGhost"))
        {
            Destroy(gameObject);
        }
        
    }
    public void ChangeSpeed(float spe)
    {
        speed = spe;
    }
}
