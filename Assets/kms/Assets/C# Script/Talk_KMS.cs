using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk_KMS : MonoBehaviour
{
    public GameObject Dialogue; // 텍스트 상자
    public Image[] Character; // 캐릭 배열
    public Text DialogueText; // 텍스트 상자안에있는 텍스트
    public Image NameTag; // 이름표
    public Text NameText; // 이름표안에 이름

    public int ClickTime; // 클릭횟수
    public bool doClick; // 클릭이 가능한가?

    [SerializeField]
    public GameObject canvas; //나의 캔버스를 받아서 끝났을 때 꺼지게 하기위함.

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
    }

    void Click() // 스페이스바 누를때 나오는 텍스트들 (대사)
    {
        if (ClickTime == 0)
        {
            NameText.text = "튜토리얼";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "스페이스 바나 마우스 좌클릭으로 넘어 갈 수 있습니다!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            NameText.text = "신사 할아버지";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "네 어머니가 제노바 사람이니?";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "네 맞아요! 혹시 어디 가신지 알 수 있을까요?";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            NameText.text = "신사 할아버지";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "코르도바라는 도시야.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "(풀이 죽으며) 아...그럼 코르도바로 가야죠.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 5)
        {
            NameText.text = "신사 할아버지";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "꼬마야 왜 그러니? 괜찮니? 잠깐 들어오너라.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 6)
        {
            NameText.text = "신사 할아버지";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "너 가진 돈은 없지? 자 마르코. 여기 리라좀 넣었다.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 7)
        {
            NameText.text = "신사 할아버지";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "마르코야. 내 말 잘들어라. 이편지를 가지고 코르도바 가거라.\n 두 시간쯤 가면 된단다. 이 편지에 적힌 신사를 찾아 가거라. 그 사람이 도와줄거야.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 8)
        {
            NameText.text = "신사 할아버지";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "가거라. 용기 잃지 말고. 어디로 가든 고향 사람들을 만날 수 있을 테니\n 넌 혼자가 아니란다. 잘가라!";
            StartCoroutine(ShowText());
            canvas.SetActive(false);
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