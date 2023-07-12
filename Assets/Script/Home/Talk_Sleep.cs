using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk_Sleep : MonoBehaviour
{
    public GameObject Dialogue; // 텍스트 상자
    public Text DialogueText; // 텍스트 상자안에있는 텍스트

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
        //SelectionRoot.SetActive(false); // 처음 시작시 끄기
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
        if(Exit.canExit == true)
        {
            gameObject.SetActive(false);
        }
    }

    void Click() // 스페이스바 누를때 나오는 텍스트들 (대사)
    {
        if (ClickTime == 0)
        {
            fullText = "그렇게 시간이 지나고.....";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            fullText = "항해 날짜가 잡혔다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            fullText = "그리고 가족은 소년의 가방에 옷을 가득 넣어주고 주머니에 얼마간의 돈을 넣어준 뒤 친척집 주소를 건네준다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            fullText = "(이제 집 밖으로 나가서 배를 타러 가자)";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            Exit.canExit = true;
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
