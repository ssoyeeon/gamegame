using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;             //게임매니저 인스턴스화

    public bool activate = true;                    //행동 가능한지 상태를 나타내는 bool 값
    public bool isGrabbed = false;                  //아이템을 들고 있는지 체크하는 변수
    public int playerHP = 0;

    public GameTime gameTime = new GameTime(0, 2, true);
    public Enums.GameSpeed gameSpeed = Enums.GameSpeed.Default;
    public Timer timeScaleConvertTimer = new Timer(5f);
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
    private void Start()
    {
        timeScaleConvertTimer.Start();
    }
    void Update()
    {
        float deltaTime = Time.deltaTime;

        if(gameSpeed != Enums.GameSpeed.Pause)
        {
            if(timeScaleConvertTimer != null)
            {
                timeScaleConvertTimer.Update(deltaTime, gameSpeed);

                if (!timeScaleConvertTimer.IsRunning())                   // 타이머가 실행중이지 않을 때
                {
                    var isDayChange = gameTime.AddMinutes(10);

                    if (isDayChange)
                    {
                        // 날짜가 바뀜
                    }
                    else
                    {
                        timeScaleConvertTimer.Start();
                    }
                }
            }
        }
    }
    
}

