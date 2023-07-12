using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GentleMan : MonoBehaviour
{
    [SerializeField]
    public GameObject canvas;
    [SerializeField]
    public GameObject gentleMan;

    void Start()
    {
        gentleMan.SetActive(true);
        canvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Person"))
        {
            canvas.SetActive(true);
            gentleMan.SetActive(false);
        }
    }

    /*private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Person"))
        {
            Debug.Log("sdsd");
            gentleMan.SetActive(false);
        }
        
    }*/

}
