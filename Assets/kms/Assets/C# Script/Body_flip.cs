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
        if (Input.GetKey(KeyCode.A)) //哭率
        {
            body.flipX = false;
        }

        if (Input.GetKey(KeyCode.D)) //坷弗率
        {
            body.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow)) //坷弗率
        {
            body.flipX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //哭率
        {
            body.flipX = false;
        }
    }
}
