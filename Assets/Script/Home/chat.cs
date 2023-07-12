using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chat : MonoBehaviour
{
    public GameObject ChatingPanel;

    private void Start()
    {
        ChatingPanel.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ChatingPanel.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.F))
        {
            ChatingPanel.SetActive(true);
        }
    }
}
