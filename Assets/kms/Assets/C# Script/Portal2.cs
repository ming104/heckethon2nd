using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal2 : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.CompareTag("Portal"))
        {
            SceneManager.LoadScene("Stage_3-2");
        }
    }
}
