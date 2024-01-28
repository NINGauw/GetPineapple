using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyFlatforms : MonoBehaviour
{
    //Hàm xử lý khi người chơi nhảy lên flatform, sẽ đặt người chơi vào lớp con của flatform này để ng chơi cùng di chuyển
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player" || (collider.gameObject.name == "Player1" || collider.gameObject.name == "Player2"))
        {
            collider.gameObject.transform.SetParent(transform);
        }
    }
    //Ngắt việc player vào lớp của flatform để không bị di chuyển theo flatforms
    private void OnTriggerExit2D(Collider2D collider)
    {
        if(collider.gameObject.name == "Player" || (collider.gameObject.name == "Player1" || collider.gameObject.name == "Player2"))
        {
            collider.gameObject.transform.SetParent(null);
        }
    }
    
    
}
