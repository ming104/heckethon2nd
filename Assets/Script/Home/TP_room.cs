using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TP_room : MonoBehaviour
{
    public GameObject marko;
    [SerializeField]
    private GameObject roomtext;
    [SerializeField]
    private Vector3 TPpos;

    private void OnTriggerStay2D(Collider2D other)
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            marko.transform.position = TPpos;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        roomtext.SetActive(true);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        roomtext.SetActive(false);
    }
}
