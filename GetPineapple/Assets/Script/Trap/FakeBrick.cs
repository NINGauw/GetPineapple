using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FakeBrick : MonoBehaviour
{
    private PlayerLife lifeOfPlayer;
    private void OnTriggerEnter2D(Collider2D collider)
    {
        lifeOfPlayer = collider.GetComponent<PlayerLife>();
        if(collider.gameObject.CompareTag("Player"))
        {
            lifeOfPlayer.Die();
        }
    }
}
