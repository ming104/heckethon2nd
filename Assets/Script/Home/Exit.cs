using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public GameObject DontExit;
    public static bool canExit;
    // Start is called before the first frame update
    void Start()
    {
        canExit = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canExit == true && Input.GetKeyDown(KeyCode.F))
        {
            // 다음씬 넘어가야함
            print("나가기");
        }
        if(canExit == false && Input.GetKeyDown(KeyCode.F))
        {
            DontExit.SetActive(true);
            Invoke("Offtext", 2f);
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (canExit == true && Input.GetKeyDown(KeyCode.F))
        {
            // 다음씬 넘어가야함
            print("나가기");
        }
        if (canExit == false && Input.GetKeyDown(KeyCode.F))
        {
            DontExit.SetActive(true);
            Invoke("Offtext", 2f);
        }
    }

    void Offtext()
    {
        DontExit.SetActive(false);
    }
}

