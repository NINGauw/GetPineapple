using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPineapple : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    private Rigidbody2D monsterRig;
    // Start is called before the first frame update
    void Start()
    {
        monsterRig = monster.GetComponent<Rigidbody2D>();
        if (monsterRig != null)
        {
            monsterRig.isKinematic = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && ItemCollector.pineapples < 5) 
        {
            if (monsterRig != null)
            {
                monsterRig.isKinematic = false;
            }
        }
    }
}
