using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIContoller : MonoBehaviour
{
    public GameManager gm;                          //�����ؾߵ�
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI hpUI;

    void Start()
    {
        gm = GameManager.instance;                  //���� ���۽� ���ӸŴ����� ������
    }

    // Update is called once per frame
    void Update()
    {
        timeUI.text = gm.time.ToString("00") + ":" + gm.minute.ToString("00");                      //UI�� ��� 
        //Tostring()�� ��ȣ �ȿ� "00"�� �־��ָ� 10�� �ڸ����� ��°���
        hpUI.text = gm.playerHP.ToString("00");
        //Hp ���ž��� 
    }
}
