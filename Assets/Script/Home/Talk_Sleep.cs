using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk_Sleep : MonoBehaviour
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
        if(Exit.canExit == true)
        {
            gameObject.SetActive(false);
        }
    }

    void Click() // �����̽��� ������ ������ �ؽ�Ʈ�� (���)
    {
        if (ClickTime == 0)
        {
            fullText = "�׷��� �ð��� ������.....";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            fullText = "���� ��¥�� ������.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            fullText = "�׸��� ������ �ҳ��� ���濡 ���� ���� �־��ְ� �ָӴϿ� �󸶰��� ���� �־��� �� ģô�� �ּҸ� �ǳ��ش�.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            fullText = "(���� �� ������ ������ �踦 Ÿ�� ����)";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            Exit.canExit = true;
            Player.chatpenel = false;
            gameObject.SetActive(false);
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
