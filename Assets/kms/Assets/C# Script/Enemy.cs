using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    //private GameObject box;
    void Start()
    {
        gameObject.transform.position = new Vector3(13f, 0f, 0f);
    }

    // Update is called once per frame
    void Update()
    {

        if(gameObject.transform.position.x < -20f)
        {
            Destroy(gameObject);
        }

        gameObject.transform.position += new Vector3(-0.1f, 0, 0);

    }
}
