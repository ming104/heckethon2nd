using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class epilogue : MonoBehaviour
{
    public GameObject Dialogue; // �ؽ�Ʈ ����
    public Text DialogueText; // �ؽ�Ʈ ���ھȿ��ִ� �ؽ�Ʈ

    public int ClickTime; // Ŭ��Ƚ��
    public bool doClick; // Ŭ���� �����Ѱ�?


    //--------------------------------------------------�ؽ�Ʈ 1���ھ� ����ϴ� �ڵ�
    public string fullText; // ��ü �ؽ�Ʈ
    private string currentText = ""; // ���� ��µǰ� �ִ� �ؽ�Ʈ
    public int Text_LengthCount; // �ؽ�Ʈ ����
    public bool TextCoroutineIsRunning; // �ؽ�Ʈ�ڷ�ƾ�� ���� ���ΰ�?
    public GameObject TextendImage; // �ؽ�Ʈ ������ �ڿ� �ؽ�Ʈ ���� �ִϸ��̼� ����

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
            fullText = "��Ӵϴ� 2���� �Ƹ���Ƽ���� ������ �ο��뽺 ���̷��� ��� ���÷� ���� � �������� �� ���� ���ְ� �־���";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            fullText = "���� ���� �Ϸ�� ���� �ȶ��ߴ� ������ ��ã�� ���ؼ� ����.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            fullText = "������ �°� �ҿ��� ���� ������ ���� ����̰� �־��� �ҳ��� ��Ӵ� ó�� ���� ������ ������ �� ���ؿ� ������ �밨�� ���ڵ��� ���� �ʾҴ�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            fullText = "������ ��Ӵϴ� 18��� 11���� �� ���̿� ������� �Ѵٴ� ��ǿ� �Ǵ����� �������, ����� ������ ǰ�� �밨�ϰ� ���� ������.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            fullText = "������ �����ο��� �̹� ���������� �� ���� �ڸ��� ��� ��縦 �ϴ� ������ ģô�� ���� ������ ���� �Ƹ���Ƽ�� ������ �˰� �ǰ�";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 5)
        {
            fullText = "�׵��� �޷ᵵ �˳��� �ְ� ��ӴϿ��� ģ���ߴ�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 6)
        {
            fullText = "��Ӵϴ� ������� �������� ������ ���� ���´�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 7)
        {
            fullText = "���� �̸� ����� ��� �ƹ����� ģô������ ������ ������ ģô�� ��ӴϿ��� ������ �����ϰ� �ٽ� ��Ӵ��� ������ �޾� �ڱ� �̿��� ������ ���ٿ� ����ٷ� �ٿ� �־���.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 8)
        {
            fullText = "��Ӵϴ� �Ѵ޿� 80���� �����µ� ���޿� �ѹ��� �����ٰ� �����־��� ������ �� ������ ���� ���� ���Ҵ�.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 9)
        {
            fullText = "������ ������� 1���� �������� �ǰ��� ���� �ʴ� ��� ª�� ������ ������ ��ӴϷκ��� �ҽ��� �����.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 10)
        {
            fullText = "������ ���������� ã�� ���ߴٰ� �߰� ����� �� �帣�� �ȴ�";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 11)
        {
            fullText = "�׷��� ������ ��� �ؾ����� ���� ������ �ϳ�? ������ ���̵���? ��� �ƹ����� ���� ���Ѵ�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 12)
        {
            fullText = "������ ū�Ƶ��� �� ���� ���� ������ ���� ���ϴ� ��Ȳ�̿���";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 13)
        {
            SceneManager.LoadScene("Home");
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

}