using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIContoller : MonoBehaviour
{
    public GameManager gm;                          //공부해야됨
    public TextMeshProUGUI timeUI;

    void Start()
    {
        gm = GameManager.instance;                  //게임 시작시 게임매니저를 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        timeUI.text = gm.time.ToString("00") + ":" + gm.minute.ToString("00");                      //UI에 출력 
        //Tostring()의 괄호 안에 "00"을 넣어주면 10의 자리까지 출력가능
    }
}
