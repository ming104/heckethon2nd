using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Left_leg_flip : MonoBehaviour
{

    [SerializeField]
    public SpriteRenderer left_leg;
    void Start()
    {
        left_leg = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //哭率
        {
            left_leg.flipX = false;
            //left_leg.transform.rotation = Quaternion.Euler(0f, 0f, 0.467f);
        }

        if (Input.GetKey(KeyCode.D)) //坷弗率
        {
            left_leg.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow)) //坷弗率
        {
            left_leg.flipX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //哭率
        {
            left_leg.flipX = false;
        }

    }
}
