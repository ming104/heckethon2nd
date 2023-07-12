using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f; // 캐릭터 이동 속도
    public float jumpForce = 5f; // 점프 힘

    private Animator ani;

    private Rigidbody2D rb;
    public bool isJumping = false;

    public static bool chatpenel;

    [Header("마르코 몸")]
    public SpriteRenderer body;
    public SpriteRenderer rightleg;
    public SpriteRenderer leftleg;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();
    }

    private void Update()
    {
        if(chatpenel == false)
        {
            PlayerMove();
        }
        
    }
    
    private void PlayerMove()
    {
        if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.Space))
        {
            ani.SetBool("LeftWalk", false);
            ani.SetBool("RightWalk", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
            ani.SetBool("LeftWalk", true);
            XflipOFF();

        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0f, 0f));

            ani.SetBool("RightWalk", true);
            XflipON();
        }

        if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            ani.SetBool("Jump", true);
            isJumping = true;
        }
    }

    void XflipON()
    {
        body.flipX = true;
        rightleg.flipX = true;
        leftleg.flipX = true;

    }
    void XflipOFF()
    {
        body.flipX = false;
        rightleg.flipX = false;
        leftleg.flipX = false;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 캐릭터가 땅에 닿으면 점프 가능 상태로 변경
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
            ani.SetBool("Jump", false);
        }
    }
}
