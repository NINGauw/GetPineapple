using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D player;
    private BoxCollider2D coll;
    private Animator playerAnimation;
    private float dirX = 0f;
    private SpriteRenderer sprite;

    [SerializeField] private LayerMask jumpableGround;
    [SerializeField] private LayerMask GreenPig;
    [SerializeField] private float jumpHigh = 12f;
    [SerializeField] private float speed = 7f;
    [SerializeField] private AudioSource JumpingSound;
    
    //Tạo enum các trạng thái của animation
    private enum MovementState {idle, running, jumping, falling}

    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        playerAnimation = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //Tạo chức năng di chuyển sang 2 bên
        dirX = Input.GetAxis("Horizontal");
        player.velocity = new Vector2(dirX * speed, player.velocity.y);
        //Nhảy
        if (Input.GetButtonDown("Jump") && IsGrounded() || IsGreenPig())
        {   
            JumpingSound.Play();
            player.velocity = new Vector2(player.velocity.x, jumpHigh);
            
        }
        UpdateAnimation();
    }
    //Quản lý trạng thái(status) của animation
     private void UpdateAnimation()
    {
        MovementState state;
        if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else state = MovementState.idle;

        if(player.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if(player.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }
        playerAnimation.SetInteger("State", (int)state);
    }
    //Hàm kiểm tra xem Player có va chạm với Ground hay không, để đặt điều kiện cho hành động nhảy
    private bool IsGrounded(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
    private bool IsGreenPig(){
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, GreenPig);
    }
}
