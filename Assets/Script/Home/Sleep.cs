using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sleep : MonoBehaviour
{
    public GameObject DontSleep;  
    public static bool canSleep;
    public GameObject SleepPanel;

    private void Start()
    {
        canSleep = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(Input.GetKeyDown(KeyCode.F) && canSleep == true)
        {
            SleepPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F) && canSleep == false)
        {
            DontSleep.SetActive(true);
            Invoke("OffText", 2f);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.F) && canSleep == true)
        {
            SleepPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.F) && canSleep == false)
        {
            DontSleep.SetActive(true);
            Invoke("OffText", 2f);
        }
    }

    void OffText()
    {
        DontSleep.SetActive(false);
    }
}
