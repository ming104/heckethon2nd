using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class tutorial : MonoBehaviour
{
    public GameObject Say;
    public int ClickTime;
    public GameObject imageobj;
    public Image image;
    public Sprite[] tutorialImage;
    public GameObject tuto_Textobj;
    public Text tuto_Text;

    // Start is called before the first frame update
    void Start()
    {
        ClickTime = 0;
        imageobj.SetActive(false);
        Say.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown)
        {
            ClickTime++;
        }
        if(ClickTime == 2)
        {
            imageobj.SetActive(true);
            Say.SetActive(false);
            image.sprite = tutorialImage[0];
            tuto_Text.text = "스페이스바 또는 마우스 좌클릭으로 다음 이야기를 볼 수 있습니다.";
        }
        if (ClickTime == 3)
        {
            image.sprite = tutorialImage[1];
            tuto_Text.text = "회색부분으로 어두워진 곳은 층이동이 가능합니다.";
        }
        if (ClickTime == 4)
        {
            image.sprite = tutorialImage[2];
            tuto_Text.text = "각 장소에는 상호작용을 할수 있습니다. 상호작용키는 \"F\"키 입니다.";
        }
        if (ClickTime == 5)
        {
            imageobj.SetActive(false);
            tuto_Text.text = "그럼 부족하지만 재미있게 즐겨주세요!";
        }
        if (ClickTime == 6)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
