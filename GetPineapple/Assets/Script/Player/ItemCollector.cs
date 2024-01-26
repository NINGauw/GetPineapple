using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{      
    public static int pineapples = 0;
    [SerializeField] private Text PineappleCount;
    [SerializeField] private AudioSource CollectSound;

   private void OnTriggerEnter2D(Collider2D collision){
    if(collision.gameObject.CompareTag("Pineapple")){
        CollectSound.Play();
        Destroy(collision.gameObject);
        pineapples++;
        PineappleCount.text = "Pineapples: " + pineapples;

    }
   }
}
