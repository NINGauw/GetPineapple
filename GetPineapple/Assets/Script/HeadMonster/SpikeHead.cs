
using Unity.VisualScripting;
using UnityEngine;

public class SpikeHead : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float range;//Khoảng cách dò tìm player
    [SerializeField] private float delay;//Khoảng nghỉ giữa các lần dò
    [SerializeField] private LayerMask playerLayer; //Xác định lớp của người dùng
    private float checkTimer;//Biến đếm thời gian truy đuổi
    private Vector3 destination;//Vị trí mục tiêu của SpikeHead
    private Vector3[] directions = new Vector3[4]; //Mảng chứa các hướng di chuyển của SpikeHead
    private bool attacking; //Kiểm tra SpikeHead có đang tấn công hay không


    void Update()
    {
        //Chỉ di chuyển khi tấn công
        if(attacking)
        transform.Translate(destination * Time.deltaTime * speed);//Di chuyển đến vị trí destination với tốc độ speed
        else
        {
            //Nếu không tấn công, SpikeHead sẽ đợi 1 khoảng delay để kiểm tra có player trong phạm hay không
            checkTimer += Time.deltaTime;
            if(checkTimer > delay)
            {
                CheckForPlayer();
            }
        }
    }
    private void CheckForPlayer()
    {
        LayerMask mask = playerLayer & ~LayerMask.GetMask("Ground");
        CalculateDirection();
        //Kiểm tra xem spikehead có thấy người chơi không (4 hướng trái phải trên dưới)
        for(int i = 0; i <directions.Length; i++)
        {
            UnityEngine.Debug.DrawRay(transform.position, directions[i], Color.red);//Hiện đường di chuyển của SpikeHead để tính toán
            //Raycast là 1 tia chiếu đi(dùng để xác định đụng độ hay hành vi)
            //Physics2D.Raycast là 1 phương thức của Physics2D để trả về thông tin nếu raycast có đang đụng độ
            //Tham số: transform.position - vị trí hiện tại của SpikeHead, direction[i] - check 4 hướng, range - tầm của raycast, playerLayer - mục tiêu chiếu đến(Tức là xác định xem raycast có đang chiếu điến lớp này không) 
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directions[i], range, mask);
            //Nếu raycast có chiếu trúng player và SpikeHead đang không di chuyển thì sẽ thực hiện:
            if(hit.collider != null && !attacking)
            {
                //Đặt trạng thái tấn công là true
                attacking = true;
                //Đặt hướng đến là phía chiếu trúng
                destination = directions[i];
                //Đặt lại checktime là 0
                checkTimer = 0;
            }
        }
    }

    private void CalculateDirection()
    {
        //Set các hướng cho array directions
        directions[0] = transform.right * range; // Đi qua phải
        directions[1] = -transform.right * range; // Đi qua trái
        directions[2] = transform.up * range; // Đi lên
        directions[3] = -transform.up * range; // Đi xuống
    }

    private void Stop()
    {
        // Hàm để dừng SpikeHead lại
        destination = transform.position; //Đặt destination về vị trí hiện tại để spikehead không di chuyển
        attacking = false;
    }
    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Xử lý đụng độ khi va chạm player
        PlayerLife player = collider.gameObject.GetComponent<PlayerLife>();
        if(collider.gameObject.name == "Player")
        {   
            player.Die();
        }
        Stop();
        if(collider.gameObject.tag == "Enemy")
        {
            Stop();
        }
    }
}
    