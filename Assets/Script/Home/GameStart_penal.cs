using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class GameStart_penal : MonoBehaviour
{
    public GameObject Dialogue; // 텍스트 상자
    public Text DialogueText; // 텍스트 상자안에있는 텍스트
    public Image NameTag; // 이름표
    public Text NameText; // 이름표안에 이름

    public int ClickTime; // 클릭횟수
    public bool doClick; // 클릭이 가능한가?


    //--------------------------------------------------텍스트 1글자씩 출력하는 코드
    public string fullText; // 전체 텍스트
    private string currentText = ""; // 현재 출력되고 있는 텍스트
    public int Text_LengthCount; // 텍스트 길이
    public bool TextCoroutineIsRunning; // 텍스트코루틴이 실행 중인가?
    public GameObject TextendImage; // 텍스트 끝나면 뒤에 텍스트 끝에 애니메이션 넣음


    void Start()
    {
        TextCoroutineIsRunning = false; // 코루틴 시작 안했으니까 False
        TextendImage.SetActive(false); // 텍스트 끝부분 이미지 끄기
        doClick = true;
        Player.chatpenel = true;
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && doClick == true || Input.GetMouseButtonDown(0) && doClick == true) // 스페이스 클릭 시 클릭횟수 1 증가, 클릭할 수 있는 상황이면 클릭 타임 증가
        {
            if (TextCoroutineIsRunning == false) // 텍스트를 쓰는 코루틴이 실행 중인가?
            {
                TextendImage.SetActive(false);
                ClickTime++;
                Click();
            }
            else
            {
                DialogueText.text = fullText; //쓰는 코루틴이 실행중이면 텍스트에다가 모든 텍스트 넣음
                Text_LengthCount = fullText.Length; // 텍스트 카운트에 텍스트 전체 길이를 넣음
                TextendImage.SetActive(true);
            }
        }
    }

    void Click() // 스페이스바 누를때 나오는 텍스트들 (대사)
    {
        if (ClickTime == 0)
        {
            NameText.text = "마르코";

            fullText = "(엄마를 찾으러 갈 사람이 나밖에 없잖아!)";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            NameText.text = "마르코";

            fullText = "(아빠에게 다시한번 부탁해보러 가야겠다.)";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            NameText.text = "마르코";

            fullText = "(아빠는 2층에 아빠 방에 있겠지?)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 3)
        {
            Player.chatpenel = false;
            gameObject.SetActive(false);
        }
    }


    IEnumerator ShowText() //텍스트 글자 한 글자 씩 출력
    {
        TextCoroutineIsRunning = true; // 코루틴이 실행 중일때
        for (Text_LengthCount = 0; Text_LengthCount <= fullText.Length; Text_LengthCount++)
        {
            currentText = fullText.Substring(0, Text_LengthCount);
            DialogueText.text = currentText;
            yield return new WaitForSeconds(0.03f);
        }
        yield return
        TextCoroutineIsRunning = false;// 코루틴이 끝났을 때
        TextendImage.SetActive(true); // 텍스트 창 뒤에 뜨는거
    }

}