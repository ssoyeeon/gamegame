using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;             //���ӸŴ��� �ν��Ͻ�ȭ

    public int time = 6;                            //���� ó�� ���� �� �����Ǵ� �⺻ �ð�
    public int minute = 00;
    public int dayCount = 0;
    public float secondTimer = 0.0f;                //����Ÿ�� ���� 5�ʰ� �Ǿ����� ���� �� 10������ ��ȯ�ϴµ��� ����� ����
    public bool activate = true;                    //�ൿ �������� ���¸� ��Ÿ���� bool ��
    public bool isGrabbed = false;                  //�������� ��� �ִ��� üũ�ϴ� ����
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

        if(secondTimer >= 5.0f)                         //����Ÿ�� 5�� �� 10�� ���
        {
            minute += 10;
            Debug.Log("5�� ���");

            secondTimer = 0.0f;
        }
        else if(minute == 60)                           //�� > �ð� ��ȯ
        {
            time += 1;
            Debug.Log("1�ð� ���");

            minute = 00;
        }
        else if(time == 24)                             //�ʿ������� �𸣰����� ���� ��ȯ
        {
            dayCount += 1;
            Debug.Log("�Ϸ簡 �������ϴ�");

            time = 0;
        }
        else if(time == 2)
        {
            activate = false;
            
            Debug.Log("���� 2�� ~ 6�� ������ Ȱ���� �� �����ϴ�");

            time = 4;
            minute = 00;                                //1�� ���� ���ð��� ���߿� ���ð��� ���� ���� �� ������ �־ ����
        }
        else if(time == 6 && minute == 0)
        {
            activate = true;
            playerHP = 100;
            
        }


    }

    
}
