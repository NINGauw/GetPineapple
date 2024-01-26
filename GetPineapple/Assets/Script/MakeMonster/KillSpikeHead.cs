using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillSpikeHead : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.CompareTag("SpikeHead")){
        
        Destroy(collision.gameObject);

    }
   }
}
