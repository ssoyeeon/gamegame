using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;             //게임매니저 인스턴스화

    public int time = 6;                            //게임 처음 시작 시 설정되는 기본 시간
    public int minute = 00;
    public int dayCount = 0;
    public float secondTimer = 0.0f;                //리얼타임 변수 5초가 되었을때 게임 내 10분으로 변환하는데에 사용할 예정
    public bool activate = true;                    //행동 가능한지 상태를 나타내는 bool 값
    public bool isGrabbed = false;                  //아이템을 들고 있는지 체크하는 변수
    public int playerHP = 0;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        secondTimer += Time.deltaTime;

        if(secondTimer >= 5.0f)                         //리얼타임 5초 당 10분 경과
        {
            minute += 10;
            Debug.Log("5초 경과");

            secondTimer = 0.0f;
        }
        else if(minute == 60)                           //분 > 시간 변환
        {
            time += 1;
            Debug.Log("1시간 경과");

            minute = 00;
        }
        else if(time == 24)                             //필요할지는 모르겠지만 일자 변환
        {
            dayCount += 1;
            Debug.Log("하루가 지났습니다");

            time = 0;
        }
        else if(time == 2)
        {
            activate = false;
            
            Debug.Log("오전 2시 ~ 6시 까지는 활동할 수 없습니다");

            time = 4;
            minute = 00;                                //1분 정도 대기시간임 나중에 대기시간을 따로 넣을 수 있으면 넣어볼 예정
        }
        else if(time == 6 && minute == 0)
        {
            activate = true;
            playerHP = 100;
            
        }


    }

    
}
