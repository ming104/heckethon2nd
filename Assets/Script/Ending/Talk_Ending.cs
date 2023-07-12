using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk_Ending : MonoBehaviour
{
    public GameObject Dialogue; // �ؽ�Ʈ ����
    public Image[] Character; // ĳ�� �迭
    public Text DialogueText; // �ؽ�Ʈ ���ھȿ��ִ� �ؽ�Ʈ
    public Image NameTag; // �̸�ǥ
    public Text NameText; // �̸�ǥ�ȿ� �̸�
    public GameObject NameTagobj;

    public int ClickTime; // Ŭ��Ƚ��
    public bool doClick; // Ŭ���� �����Ѱ�?

    //---------------------------------------------------
    [Serializable] // ����ȭ(�ν����� â�� ���̰� �ϱ� ����)
    public struct SelectionTextButton // ������ ��ư, �ؽ�Ʈ
    {
        public Button Selection; // ��ư
        public Text SelectionText; // ��ư �ؽ�Ʈ
    }

    //--------------------------------------------------�ؽ�Ʈ 1���ھ� ����ϴ� �ڵ�
    public string fullText; // ��ü �ؽ�Ʈ
    private string currentText = ""; // ���� ��µǰ� �ִ� �ؽ�Ʈ
    public int Text_LengthCount; // �ؽ�Ʈ ����
    public bool TextCoroutineIsRunning; // �ؽ�Ʈ�ڷ�ƾ�� ���� ���ΰ�?
    public GameObject TextendImage; // �ؽ�Ʈ ������ �ڿ� �ؽ�Ʈ ���� �ִϸ��̼� ����

    //----------------��ư ����ü �迭--------------
    //public GameObject SelectionRoot; // ������ �θ�
    //public SelectionTextButton[] selectionArray; // ����ü �迭 ����

    void Start()
    {
        TextCoroutineIsRunning = false; // �ڷ�ƾ ���� �������ϱ� False
        TextendImage.SetActive(false); // �ؽ�Ʈ ���κ� �̹��� ����
        doClick = true;
        Player.chatpenel = true;
        //SelectionRoot.SetActive(false); // ó�� ���۽� ����
        
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doClick == true || Input.GetMouseButtonDown(0) && doClick == true) // �����̽� Ŭ�� �� Ŭ��Ƚ�� 1 ����, Ŭ���� �� �ִ� ��Ȳ�̸� Ŭ�� Ÿ�� ����
        {
            if (TextCoroutineIsRunning == false) // �ؽ�Ʈ�� ���� �ڷ�ƾ�� ���� ���ΰ�?
            {
                TextendImage.SetActive(false);
                ClickTime++;
                Click();
            }
            else
            {
                DialogueText.text = fullText; //���� �ڷ�ƾ�� �������̸� �ؽ�Ʈ���ٰ� ��� �ؽ�Ʈ ����
                Text_LengthCount = fullText.Length; // �ؽ�Ʈ ī��Ʈ�� �ؽ�Ʈ ��ü ���̸� ����
                TextendImage.SetActive(true);
            }
        }
        if (Sleep.canSleep == true)
        {
            gameObject.SetActive(false);
        }
    }

    void Click() // �����̽��� ������ ������ �ؽ�Ʈ�� (���)
    {
        if (ClickTime == 0)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�������� ��Ӵϴ� �����׽� ������ ��� �������� 1�� �濡 ���� �����־���.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "������ ��ӵ� ��Ÿ� �̻�� �ǰ��� �ص��� �������� �Ǿ���.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�׳�� 2���� ���� ħ�뿡�� �Ͼ�� ���ߴ�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            NameTagobj.SetActive(true);
            NameText.text = "��Ӵ�";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�ƴϿ��� ���ξ ���� �̰ܳ� ���� �����.. ���� ȥ�� �״� ���� ���ƿ�. �������� ������ � ������ ���ƴ��� �� ä �װ� �;��..";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "���� �κδ� ����ؼ� ������ ���������� �������� ��Ӵϴ� ������ �ص� ���� �ʴ´ٰ� �����ؼ� ������ ��� �ź��ߴ�.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            NameTagobj.SetActive(true);
            NameText.text = "���� ����";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(255, 255, 255, 255);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�ϴ��� �ǻ縦 �ҷ��߰ھ��";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�ǻ縦 �θ���� ������ �ǻ�� ��ħ�� �Ǿ� �� �� �ִٰ� �ߴ�";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 6)
        {
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "��ΰ� �����ϱ� �����߰� �������� ��Ƶ�� ������ ���� ������ ������ ��ü�� ���ĺ��� ������ �����ϰ� �׸����ϴ� �������� �´ٴ� �� ��� �� �� �־���.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 7)
        {
            NameTagobj.SetActive(true);
            NameText.text = "��Ӵ�";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�ϴ���, �ϴ���, �̷��� �ָ��� �״°ǰ���, �ٽ� �������°ǰ���? ��Ÿ��� ���� ���̵� �츮 �����ڴ� ����� �丸ŭ �ۿ� �ȵ����� ���� ���ϰ� ������ �����ε���! ";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 7)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�����̿���.. �����ڴ� ���ﰡ�� ���� ��ð��� ���� �� Ż�� ���°� �Ǿ� �Ŵ��� ���� ������ �־���. �����ڴ� ���� �������� ���� ������ ���� ���ø��� ���� ���� ����ؼ� �ɾ���.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 8)
        {
           
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�׳� ��ħ 8�� �ǻ�� ������ �Բ� ������ ����ؼ� ������ �ϰ��־���. ������ �������� ������ ������ ���� �� �ִٴ� ���� ���� �ʾҴ�.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 8)
        {
          
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "����� �ى�ٰ� ���� �������� ������ ������ ���� �� �ִٴ� �ǻ��� ���� ���� ���� �ʾҴ�. �������� ������ ���� ���ǵ��� �����鿡�� �����޶�� �ϰ� �ڽ��� �ϴ� ���� ������ �� �����޶�� �ߴ�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 9)
        {
            
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�� �� ���� ���ʿ��� ���ε��� ����������� �Ҹ��� �Ұ�Ұ��� �Ҹ��� ��� ���θ����� ������ ���� Ȯ���� �ϴ¼��� ����� ���� ���� ������";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 10)
        {
            NameTagobj.SetActive(true);
            NameText.text = "���� ����";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(255, 255, 255, 255);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "��.. ���ġ�� ���� �ι��� �Գ׿�...";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 11)
        {
            NameText.text = "���� ����";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(255, 255, 255, 255);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "���� �ܴ��� �Ծ��. � ����� ������ �� �ſ���. ����� ���� ����ϴ� ����̿�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 12)
        {
            NameText.text = "��Ӵ�";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "������..?";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 13)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�����ڰ� ���տ� ���־���.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 14)
        {
            NameTagobj.SetActive(true);
            NameText.text = "��Ӵ�";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�� �ϴ���! �ϴ���! �ϴ���!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 15)
        {
            NameText.text = "��Ӵ�";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "���� ��� �Դ�? �� �°ž�? ��¥ �ʴ�? ���� ���� �Ǳ���! ���� ���������? �� ȥ�ھ�? ���µ��� ����? ��¥ �����ڱ���! ���� �ƴϾ�! ����! �� �� �غ���!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 16)
        {
            NameText.text = "��Ӵ�";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "��� ��� ������ �ǻ� ������! ���! �ǰ������� �;��! �� �غ� �Ǿ����. 1���̶� ������!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 18)
        {
            NameText.text = "������";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "���� ���̿���? �츮�������� ���� �� �־��? �������� �� �Ϸ��� �ſ���?";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 18)
        {
            NameText.text = "���θ���";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(255, 255, 255, 255);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�� ��� �ߵ���. ���� �����ָ�. �� ��Ӵϰ� ���� �����ż� ������ ������ �޾ƾ� �Ѵܴ�. ���� �� ���������״� ���� ���� ����";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 19)
        {
            NameText.text = "������";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�Ⱦ��! ���� ���� ��������!";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 20)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "��ȿ��� ġ������ ��ó�� ���� ����� �������� ���� ���Ҹ��� ����´�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 21)
        {
            NameTagobj.SetActive(true);
            NameText.text = "������";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "������ ���ư��̾�!";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 22)
        {
            NameText.text = "�ǻ�";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(255, 255, 255, 255);
            fullText = "�ƴ� �� ������ �����ϴܴ�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 23)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�����ڴ� ���ϴ� �ǻ缱������ �ٶ󺸴� ������ ���� �����.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 24)
        {
            NameText.text = "������";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�����մϴ٤̤� �ǻ缱����!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 25)
        {
            NameText.text = "�ǻ�";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(255, 255, 255, 255);
            fullText = "�Ͼ��. �״��̾� ��������, �װ� ��Ӵϸ� ���ߴܴ�!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 26)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�׷��� �����ڿ� ��Ӵϴ� ���θ����� ������ ���������־���.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 27)
        {
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "�ױ����� �ƺ��� ���� �������ָ鼭 �������־���.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 28)
        {
            // ũ����
        }
    }


    IEnumerator ShowText() //�ؽ�Ʈ ���� �� ���� �� ���
    {
        TextCoroutineIsRunning = true; // �ڷ�ƾ�� ���� ���϶�
        for (Text_LengthCount = 0; Text_LengthCount <= fullText.Length; Text_LengthCount++)
        {
            currentText = fullText.Substring(0, Text_LengthCount);
            DialogueText.text = currentText;
            yield return new WaitForSeconds(0.03f);
        }
        yield return
        TextCoroutineIsRunning = false;// �ڷ�ƾ�� ������ ��
        TextendImage.SetActive(true); // �ؽ�Ʈ â �ڿ� �ߴ°�
    }

    //SelectionButton ��ư ó��
    //public void SelectionButton1()
    //{
    //    doClick = true; // �ٽ� Ŭ�� �����ϰ� �ٲ�
    //    SelectionRoot.SetActive(false); // ����â ����
    //}

    //public void SelectionButton2()
    //{
    //    doClick = true; // �ٽ� Ŭ�� �����ϰ� �ٲ�
    //    SelectionRoot.SetActive(false); // ����â ����
    //}
}