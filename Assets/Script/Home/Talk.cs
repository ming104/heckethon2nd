using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk : MonoBehaviour
{
    public GameObject Dialogue; // 텍스트 상자
    public Image[] Character; // 캐릭 배열
    public Text DialogueText; // 텍스트 상자안에있는 텍스트
    public Image NameTag; // 이름표
    public Text NameText; // 이름표안에 이름

    public int ClickTime; // 클릭횟수
    public bool doClick; // 클릭이 가능한가?

    //---------------------------------------------------
    [Serializable] // 직렬화(인스펙터 창에 보이게 하기 위함)
    public struct SelectionTextButton // 선택지 버튼, 텍스트
    {
        public Button Selection; // 버튼
        public Text SelectionText; // 버튼 텍스트
    }

    //--------------------------------------------------텍스트 1글자씩 출력하는 코드
    public string fullText; // 전체 텍스트
    private string currentText = ""; // 현재 출력되고 있는 텍스트
    public int Text_LengthCount; // 텍스트 길이
    public bool TextCoroutineIsRunning; // 텍스트코루틴이 실행 중인가?
    public GameObject TextendImage; // 텍스트 끝나면 뒤에 텍스트 끝에 애니메이션 넣음

    //----------------버튼 구조체 배열--------------
    //public GameObject SelectionRoot; // 선택지 부모
    //public SelectionTextButton[] selectionArray; // 구조체 배열 선언

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
        if (Sleep.canSleep == true)
        {
            gameObject.SetActive(false);
        }
    }

    void Click() // 스페이스바 누를때 나오는 텍스트들 (대사)
    {
        if (ClickTime == 0)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "제가 아르헨티나로 가서 엄마를 찾을래요!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            NameText.text = "아빠";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "안돼 13살이 혼자가겠다는건 너무 위험해서 안돼!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "다른 사람들도 갔잖아요. 저보다 어린 아이들도요. 저도 배만 타면 그들처럼 그 곳에 갈 수 있어요! 도착해서 친척 아저씨의 상점만 찾으면 돼요.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "그러면 엄마가 계신 곳도 찾는 거고요. 혹시 아저씨를 못만나면 영사관으로 가서 아르헨티나인 가족을 찾아볼게요. 무슨일이 생긴다해도 거긴 일자리가 많다니까 제가 할 일을 찾아볼게요.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "집에 돌아올 정도는 벌 수 있겠죠.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            NameText.text = "아빠";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "하아..... 좋다 그러면 내 지인의 친구에게 아르헨티나로 가는 삼등칸 표를 구해달라고 부탁해보마.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "(아르헨티나에 가는걸 승낙 받았으니 내 방으로 가서 잠을 자자)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 7)
        {
            Sleep.canSleep = true;
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

    //SelectionButton 버튼 처리
    //public void SelectionButton1()
    //{
    //    doClick = true; // 다시 클릭 가능하게 바꿈
    //    SelectionRoot.SetActive(false); // 선택창 꺼짐
    //}

    //public void SelectionButton2()
    //{
    //    doClick = true; // 다시 클릭 가능하게 바꿈
    //    SelectionRoot.SetActive(false); // 선택창 꺼짐
    //}
}