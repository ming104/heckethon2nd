using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_maneger : MonoBehaviour
{
  
    public void OnClick()
    {
        SceneManager.LoadScene("Stage_1");
    }

   

}
