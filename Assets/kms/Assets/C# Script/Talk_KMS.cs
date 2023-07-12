using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk_KMS : MonoBehaviour
{
    public GameObject Dialogue; // �ؽ�Ʈ ����
    public Image[] Character; // ĳ�� �迭
    public Text DialogueText; // �ؽ�Ʈ ���ھȿ��ִ� �ؽ�Ʈ
    public Image NameTag; // �̸�ǥ
    public Text NameText; // �̸�ǥ�ȿ� �̸�

    public int ClickTime; // Ŭ��Ƚ��
    public bool doClick; // Ŭ���� �����Ѱ�?

    [SerializeField]
    public GameObject canvas; //���� ĵ������ �޾Ƽ� ������ �� ������ �ϱ�����.

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
    }

    void Click() // �����̽��� ������ ������ �ؽ�Ʈ�� (���)
    {
        if (ClickTime == 0)
        {
            NameText.text = "Ʃ�丮��";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "�����̽� �ٳ� ���콺 ��Ŭ������ �Ѿ� �� �� �ֽ��ϴ�!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            NameText.text = "�Ż� �Ҿƹ���";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "�� ��Ӵϰ� ����� ����̴�?";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            NameText.text = "������";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "�� �¾ƿ�! Ȥ�� ��� ������ �� �� �������?";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            NameText.text = "�Ż� �Ҿƹ���";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "�ڸ����ٶ�� ���þ�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            NameText.text = "������";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "(Ǯ�� ������) ��...�׷� �ڸ����ٷ� ������.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 5)
        {
            NameText.text = "�Ż� �Ҿƹ���";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "������ �� �׷���? ������? ��� �����ʶ�.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 6)
        {
            NameText.text = "�Ż� �Ҿƹ���";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "�� ���� ���� ����? �� ������. ���� ������ �־���.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 7)
        {
            NameText.text = "�Ż� �Ҿƹ���";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "�����ھ�. �� �� �ߵ���. �������� ������ �ڸ����� ���Ŷ�.\n �� �ð��� ���� �ȴܴ�. �� ������ ���� �Ż縦 ã�� ���Ŷ�. �� ����� �����ٰž�.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 8)
        {
            NameText.text = "�Ż� �Ҿƹ���";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "���Ŷ�. ��� ���� ����. ���� ���� ���� ������� ���� �� ���� �״�\n �� ȥ�ڰ� �ƴ϶���. �߰���!";
            StartCoroutine(ShowText());
            canvas.SetActive(false);
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