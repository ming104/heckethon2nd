using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage_3_Player : MonoBehaviour
{
    public Vector2 inputVec;
    public float playerSpeed = 5.0f;
    public float jumpPower = 10.0f;
    public int Jump;

    [SerializeField]
    private GameObject player;

    Rigidbody2D rigid;

    void Start()
    {
        Jump = 0;
        rigid = GetComponent<Rigidbody2D>();
        transform.position = new Vector2(-51, -7);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        /*inputVec.x = Input.GetAxis("Horizontal");
        *//*inputVec.y = Input.GetAxis("Vertical");*/
        //rigid.MovePosition(rigid.position + inputVec);
    }


    void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A)) //왼쪽
        {
            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));

        }

        if (Input.GetKey(KeyCode.D)) //오른쪽
        {
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));

        }

        if (Input.GetKey(KeyCode.RightArrow)) //오른쪽
        {
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));

        }

        if (Input.GetKey(KeyCode.LeftArrow)) //왼쪽
        {
            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));

        }

        if (Input.GetKeyDown(KeyCode.Space) && Jump == 0) //점프
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            Jump++; //점프할때 jump++를 통해서 함.
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) // 콜리전 충돌 시작
    {
        if (collision.gameObject.CompareTag("Floor"))// 바닥과 닿았는가? (*바닥에 "Floor" 태그를 붙여야 함)
        {
            Jump = 0; // 점프 중이 아님
        }
    }

}
