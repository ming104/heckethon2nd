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
        if (Input.GetKey(KeyCode.A)) //����
        {
            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));

        }

        if (Input.GetKey(KeyCode.D)) //������
        {
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));

        }

        if (Input.GetKey(KeyCode.RightArrow)) //������
        {
            transform.Translate(new Vector3(playerSpeed * Time.deltaTime, 0, 0));

        }

        if (Input.GetKey(KeyCode.LeftArrow)) //����
        {
            transform.Translate(new Vector3(-playerSpeed * Time.deltaTime, 0, 0));

        }

        if (Input.GetKeyDown(KeyCode.Space) && Jump == 0) //����
        {
            rigid.AddForce(Vector3.up * jumpPower, ForceMode2D.Impulse);
            Jump++; //�����Ҷ� jump++�� ���ؼ� ��.
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) // �ݸ��� �浹 ����
    {
        if (collision.gameObject.CompareTag("Floor"))// �ٴڰ� ��Ҵ°�? (*�ٴڿ� "Floor" �±׸� �ٿ��� ��)
        {
            Jump = 0; // ���� ���� �ƴ�
        }
    }

}
