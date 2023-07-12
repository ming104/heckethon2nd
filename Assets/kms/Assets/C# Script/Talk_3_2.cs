using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk_3_2 : MonoBehaviour
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
        //수정
        if (ClickTime == 1)
        {
            NameText.text = "집사";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "무슨 일이지? 주인님은 안계셔.\n 어제 오후에 가족들과 함께 부에노스아이레스로 떠났단다";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 2)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "하지만 전...저는 아는 사람이 없어요! (편지를 건넨다.)";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 3)
        {
            NameText.text = "집사";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "(통명스럽게) 난 해줄 수 있는게 없단다. \n 이건 한달 뒤에 주인님이 돌아오면 드리도록 하지.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 4)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            fullText = "하지만 전 혼자라서 도움이 필요해요!";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            NameText.text = "집사";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            fullText = "뭐야? 허 참... 로사리오엔 너 같은 이탈리아인들이 차고 넘친단 말이야! \n 꺼져. 구걸은 니네 나라가서 해!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 6)
        {
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