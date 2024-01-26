using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakeGhostGo : MonoBehaviour
{
    [SerializeField] private GameObject ghost;
    [SerializeField] private float ghostSpeed;
    private GhostAI ghostai;
    void Start()
    {
        ghostai = ghost.GetComponent<GhostAI>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            ghostai.ChangeSpeed(ghostSpeed);
        }
    }
    
}
