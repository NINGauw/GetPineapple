using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadishAI : MonoBehaviour
{
    private Transform playerPos;
    //Vector là lưu vị trí
    private Vector2 currentPos;
    private Animator RadishAnimator;
    [SerializeField]public GameObject player;
    [SerializeField] private float distance;
    [SerializeField] public float speed;
    [SerializeField] private AudioSource RadishCatch;
    [SerializeField] private GameObject Location;
    
    
    void Start()
    {
        RadishAnimator = GetComponent<Animator>();
        playerPos = player.GetComponent<Transform>();
        //currentPos là biến lưu vị trí gốc của Radish
        currentPos = GetComponent<Transform>().position;
    }

    void Update()
    {
        Vector2 direction = (playerPos.position - transform.position).normalized;
        //Nếu vị trí hiện tại của Radish đến vị trí player nhỏ hơn biến distance
        if(Vector2.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPos.position, speed * Time.deltaTime);
            RadishAnimator.SetBool("IsChase", true);

            if (direction.x > 0)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else if (direction.x < 0)
                {
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
        }
        else
        {
            if(Vector2.Distance(transform.position, currentPos) <= 0)
            {
                RadishAnimator.SetBool("IsChase", false);
                
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, currentPos, speed * Time.deltaTime);
                RadishAnimator.SetBool("IsChase", true);

                if (direction.x > 0)
                {
                    transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
                else if (direction.x < 0)
                {
                    transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
           RadishCatch.Play();
           collider.gameObject.transform.position = Location.transform.position;
        }
        
    }
}
