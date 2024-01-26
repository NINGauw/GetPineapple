using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMonsterLeft : MonoBehaviour
{
    [SerializeField] private GameObject monster;
    [SerializeField] private float range;
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
        
        if (other.CompareTag("Player")) 
        {
            monsterRig.velocity = new Vector2(-range, monsterRig.velocity.y);
        }
    }
}
