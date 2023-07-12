using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP : MonoBehaviour
{
    public GameObject marko;
    [SerializeField]
    private Vector3 TPpos;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            marko.transform.position = TPpos;
        }
    }
}
