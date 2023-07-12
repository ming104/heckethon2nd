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
            tuto_Text.text = "�����̽��� �Ǵ� ���콺 ��Ŭ������ ���� �̾߱⸦ �� �� �ֽ��ϴ�.";
        }
        if (ClickTime == 3)
        {
            image.sprite = tutorialImage[1];
            tuto_Text.text = "ȸ���κ����� ��ο��� ���� ���̵��� �����մϴ�.";
        }
        if (ClickTime == 4)
        {
            image.sprite = tutorialImage[2];
            tuto_Text.text = "�� ��ҿ��� ��ȣ�ۿ��� �Ҽ� �ֽ��ϴ�. ��ȣ�ۿ�Ű�� \"F\"Ű �Դϴ�.";
        }
        if (ClickTime == 5)
        {
            imageobj.SetActive(false);
            tuto_Text.text = "�׷� ���������� ����ְ� ����ּ���!";
        }
        if (ClickTime == 6)
        {
            SceneManager.LoadScene("StartScene");
        }
    }
}
