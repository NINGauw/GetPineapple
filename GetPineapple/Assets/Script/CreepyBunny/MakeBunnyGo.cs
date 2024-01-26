using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBunnyGo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bunny;
    private CreepyBunnyAI moving;
    void Start()
    {
         moving = bunny.GetComponent<CreepyBunnyAI>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("trigger");
            moving.ChangeSpeed(7f);
        }
    }
}
