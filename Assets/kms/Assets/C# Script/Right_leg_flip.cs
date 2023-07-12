using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right_leg_flip : MonoBehaviour
{
    [SerializeField]
    public SpriteRenderer right_leg;
    void Start()
    {
        right_leg = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A)) //����
        {
            right_leg.flipX = false;
        }

        if (Input.GetKey(KeyCode.D)) //������
        {
            right_leg.flipX = true;
        }

        if (Input.GetKey(KeyCode.RightArrow)) //������
        {
            right_leg.flipX = true;
        }

        if (Input.GetKey(KeyCode.LeftArrow)) //����
        {
            right_leg.flipX = false;
        }
    } 


}
