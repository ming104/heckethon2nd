using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class Talk_Ending : MonoBehaviour
{
    public GameObject Dialogue; // 텍스트 상자
    public Image[] Character; // 캐릭 배열
    public Text DialogueText; // 텍스트 상자안에있는 텍스트
    public Image NameTag; // 이름표
    public Text NameText; // 이름표안에 이름
    public GameObject NameTagobj;

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
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "마르코의 어머니는 메퀴네스 가족이 사는 대저택의 1층 방에 병상에 누워있었다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 1)
        {
            
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "하지만 계속된 장거리 이사로 건강은 극도로 나빠지게 되었다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 2)
        {
            
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "그녀는 2주일 동안 침대에서 일어나지 못했다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 3)
        {
            NameTagobj.SetActive(true);
            NameText.text = "어머니";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "아니에요 주인어른 저는 이겨낼 힘이 없어요.. 차라리 혼자 죽는 편이 나아요. 가족들이 저에게 어떤 불행이 닥쳤는지 모른 채 죽고 싶어요..";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 4)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "주인 부부는 계속해서 수술을 권유했지만 마르코의 어머니는 수술을 해도 낫지 않는다고 생각해서 수술을 계속 거부했다.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            NameTagobj.SetActive(true);
            NameText.text = "주인 마님";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(255, 255, 255, 255);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "일단은 의사를 불러야겠어요";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 5)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "의사를 부르기는 했지만 의사는 아침이 되야 올 수 있다고 했다";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 6)
        {
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "모두가 걱정하기 시작했고 몸무림이 잦아드는 순간이 오면 끔찍한 고통은 육체의 아픔보다 가족을 걱정하고 그리워하는 마음에서 온다는 걸 모두 알 수 있었다.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 7)
        {
            NameTagobj.SetActive(true);
            NameText.text = "어머니";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "하느님, 하느님, 이렇게 멀리서 죽는건가요, 다시 못만나는건가요? 안타까운 나의 아이들 우리 마르코는 어려서 요만큼 밖에 안되지만 정말 착하고 다정한 아이인데요! ";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 7)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "자정이였다.. 마르코는 개울가를 따라 몇시간을 걸은 뒤 탈진 상태가 되어 거대한 숲을 지나고 있었다. 마르코는 점점 선명해져 가는 엄마의 얼굴을 떠올리면 힘을 내며 계속해서 걸었다.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 8)
        {
           
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "그날 아침 8시 의사는 조수와 함께 수술을 계속해서 권유를 하고있었다. 하지만 마르코의 엄마는 수술로 나을 수 있다는 말을 믿지 않았다.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 8)
        {
          
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "기력이 다됬다고 여긴 마르코의 엄마는 수술로 나을 수 있다는 의사의 말을 전혀 믿지 않았다. 마르코의 엄마는 돈과 물건들을 가족들에게 보내달라고 하고 자신이 하는 말을 편지로 써 보내달라고 했다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 9)
        {
            
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "그 때 였다 문쪽에서 하인들이 웅성웅성대는 소리와 소곤소곤대는 소리가 들려 주인마님이 밖으로 나가 확인을 하는순간 놀라지 않을 수가 없었다";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 10)
        {
            NameTagobj.SetActive(true);
            NameText.text = "주인 마님";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(255, 255, 255, 255);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "어.. 상상치도 못한 인물이 왔네요...";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 11)
        {
            NameText.text = "주인 마님";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(255, 255, 255, 255);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "마음 단단히 먹어요. 어떤 사람을 만나게 될 거예요. 당신이 아주 사랑하는 사람이요.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 12)
        {
            NameText.text = "어머니";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "누구요..?";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 13)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "마르코가 문앞에 서있었다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 14)
        {
            NameTagobj.SetActive(true);
            NameText.text = "어머니";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "오 하느님! 하느님! 하느님!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 15)
        {
            NameText.text = "어머니";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "여긴 어떻게 왔니? 왜 온거야? 진짜 너니? 정말 많이 컸구나! 누가 데려다줬어? 너 혼자야? 아픈데는 없고? 진짜 마르코구나! 꿈이 아니야! 세상에! 말 좀 해보렴!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 16)
        {
            NameText.text = "어머니";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(255, 255, 255, 255);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "잠깐 잠깐 빨리요 의사 선생님! 어서요! 건강해지고 싶어요! 전 준비가 되었어요. 1분이라도 빨리요!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 18)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "무슨 일이예요? 우리엄마한테 무슨 일 있어요? 엄마한테 뭘 하려는 거예요?";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 18)
        {
            NameText.text = "주인마님";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(255, 255, 255, 255);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "자 얘야 잘들어보렴. 내가 말해주마. 네 어머니가 많이 아프셔서 간단한 수술을 받아야 한단다. 전부 다 설명해줄테니 나와 같이 가자";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 19)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "싫어요! 저도 같이 있을래요!";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 20)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "방안에선 치명적인 상처를 입은 사람이 내지르는 듯한 비명소리가 들려온다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 21)
        {
            NameTagobj.SetActive(true);
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "엄마가 돌아가셨어!";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 22)
        {
            NameText.text = "의사";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(255, 255, 255, 255);
            fullText = "아니 네 엄마는 무사하단다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 23)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "마르코는 멍하니 의사선생님을 바라보다 쓰러져 엉엉 울었다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 24)
        {
            NameText.text = "마르코";
            Character[0].color = new Color32(255, 255, 255, 255);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "감사합니다ㅜㅜ 의사선생님!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 25)
        {
            NameText.text = "의사";
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(255, 255, 255, 255);
            fullText = "일어나렴. 네덕이야 꼬마영웅, 네가 어머니를 구했단다!";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 26)
        {
            NameTagobj.SetActive(false);
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "그렇게 마르코와 어머니는 주인마님이 집으로 돌려보내주었다.";
            StartCoroutine(ShowText());
        }
        if (ClickTime == 27)
        {
            Character[0].color = new Color32(150, 150, 150, 150);
            Character[1].color = new Color32(150, 150, 150, 150);
            Character[2].color = new Color32(150, 150, 150, 150);
            Character[3].color = new Color32(150, 150, 150, 150);
            fullText = "항구에서 아빠와 형이 맞이해주면서 축하해주었다.";
            StartCoroutine(ShowText());
        }

        if (ClickTime == 28)
        {
            // 크레딧
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