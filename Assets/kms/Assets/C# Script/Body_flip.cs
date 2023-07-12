using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_flip : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer body;
    void Start()
    {
        body = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //����
        {
            body.flipX = false;
        }

        if (Input.GetKey(KeyCode.D)) //������
        {
            body.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow)) //������
        {
            body.flipX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //����
        {
            body.flipX = false;
        }
    }
}
