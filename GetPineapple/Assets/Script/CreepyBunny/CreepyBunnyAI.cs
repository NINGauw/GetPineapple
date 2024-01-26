using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreepyBunnyAI : MonoBehaviour
{
    private int currentWaypointIndex = 0;
    private Vector3 originalScale;
    [SerializeField] private float speed = 2f; 
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private AudioSource BunnyCatch;
    [SerializeField] private GameObject Location;
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
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
           BunnyCatch.Play();
           collider.gameObject.transform.position = Location.transform.position;
        }
        
    }
    public void ChangeSpeed(float spe)
    {
        speed = spe;
    }
}
