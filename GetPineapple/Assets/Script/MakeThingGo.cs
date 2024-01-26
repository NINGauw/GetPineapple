using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MakeThingGo : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject things;
    private FlatformMoving moving;
    void Start()
    {
        moving = things.AddComponent<FlatformMoving>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.CompareTag("Player"))
        {
            Debug.Log("trigger");
            moving.ChangeSpeed(8f);
        }
    }
}
