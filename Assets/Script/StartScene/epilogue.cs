using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class epilogue : MonoBehaviour
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
            fullText = "어머니는 2년전 아르헨티나의 수도인 부에노스 아이레스 라는 도시로 떠나 어떤 부잣집에 들어가 일을 해주고 있었다";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            fullText = "돈을 벌어 하루라도 빨리 안락했던 가정을 되찾기 위해서 였다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            fullText = "가족은 온갖 불운이 겹쳐 가난과 빚에 허덕이고 있었고 소년의 어머니 처럼 집안 형편을 돕고자 긴 항해에 나서는 용감한 여자들이 적지 않았다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            fullText = "가엾은 어머니는 18살과 11살인 두 아이와 헤어져야 한다는 사실에 피눈물을 흘렸지만, 희망을 마음에 품고 용감하게 길을 떠났다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            fullText = "여행은 순조로웠고 이미 오래전부터 그 곳에 자리를 잡고 장사를 하는 남편의 친척을 통해 마음씨 좋은 아르헨티나 가족을 알게 되고";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 5)
        {
            fullText = "그들은 급료도 넉넉히 주고 어머니에게 친절했다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 6)
        {
            fullText = "어머니는 제노바의 가족에게 편지를 자주 보냈다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 7)
        {
            fullText = "서로 미리 약속한 대로 아버지가 친척앞으로 편지를 보내면 친척이 어머니에게 편지를 전달하고 다시 어머니의 답장을 받아 자기 이여기 몇줄을 더붙여 제노바로 붙여 주었다.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 8)
        {
            fullText = "어머니는 한달에 80리라를 벌었는데 석달에 한번씩 집에다가 부쳐주었고 남편은 그 돈으로 급한 빚을 갚았다.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 9)
        {
            fullText = "하지만 헤어진지 1년이 지났을때 건강이 좋지 않다 라는 짧은 편지를 끝으로 어머니로부터 소식이 끊겼다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 10)
        {
            fullText = "편지를 보내봤지만 찾지 못했다고 했고 몇달이 더 흐르게 된다";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 11)
        {
            fullText = "그러자 남편은 어떻게 해야하지 내가 가봐야 하나? 하지만 아이들은? 라며 아버지도 가지 못한다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 12)
        {
            fullText = "하지만 큰아들은 막 돈을 벌기 시작해 가지 못하는 상황이였다";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 13)
        {
            SceneManager.LoadScene("Home");
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