using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMonsterUp : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private float range;
    private Rigidbody2D monsterRig;
    void Start()
    {
        monsterRig = monster.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player")) 
        {
            monsterRig.velocity = new Vector2(monsterRig.velocity.x, range);
        }
    }
}
