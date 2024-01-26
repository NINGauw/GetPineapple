using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeMonsterFallByRockHead : MonoBehaviour
{
    [SerializeField] private GameObject[] monster;
    private Rigidbody2D monsterRig0;
    private Rigidbody2D monsterRig1;
    private Rigidbody2D monsterRig2;
    private Rigidbody2D monsterRig3;
    private Rigidbody2D monsterRig4;
    // Start is called before the first frame update
    void Start()
    {
        monsterRig0 = monster[0].GetComponent<Rigidbody2D>();
        monsterRig1 = monster[1].GetComponent<Rigidbody2D>();
        monsterRig2 = monster[2].GetComponent<Rigidbody2D>();
        monsterRig3 = monster[3].GetComponent<Rigidbody2D>();
        monsterRig4 = monster[4].GetComponent<Rigidbody2D>();


        if (monsterRig0 != null)
        {
            monsterRig0.isKinematic = true;
        }
        if (monsterRig1 != null)
        {
            monsterRig1.isKinematic = true;
        }
        if (monsterRig2 != null)
        {
            monsterRig2.isKinematic = true;
        }
        if (monsterRig3 != null)
        {
            monsterRig3.isKinematic = true;
        }
        if (monsterRig4 != null)
        {
            monsterRig4.isKinematic = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Enemy")) 
        {
            if (monsterRig0 != null)
            {
                monsterRig0.isKinematic = false;
            }
            if (monsterRig1 != null)
            {
                monsterRig1.isKinematic = false;
            }
            if (monsterRig2 != null)
            {
                monsterRig2.isKinematic = false;
            }
            if (monsterRig3 != null)
            {
                monsterRig3.isKinematic = false;
            }
            if (monsterRig4 != null)
            {
                monsterRig4.isKinematic = false;
            }
        }
    }
}
