using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;             //���ӸŴ��� �ν��Ͻ�ȭ

    public bool activate = true;                    //�ൿ �������� ���¸� ��Ÿ���� bool ��
    public bool isGrabbed = false;                  //�������� ��� �ִ��� üũ�ϴ� ����
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

                if (!timeScaleConvertTimer.IsRunning())                   // Ÿ�̸Ӱ� ���������� ���� ��
                {
                    var isDayChange = gameTime.AddMinutes(10);

                    if (isDayChange)
                    {
                        // ��¥�� �ٲ�
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

