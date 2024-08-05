using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIContoller : MonoBehaviour
{
    public GameManager gm;                          //공부해야됨
    public TextMeshProUGUI timeUI;
    public TextMeshProUGUI hpUI;

    void Start()
    {
        gm = GameManager.instance;                  //게임 시작시 게임매니저를 가져옴
    }

    // Update is called once per frame
    void Update()
    {
        timeUI.text = $"{((gm.gameTime.GetDay() == 0 )? "" : gm.gameTime.GetDay().ToString() + "일차")} " +
            $"{gm.gameTime.GetHour()}시 {gm.gameTime.GetMinute()}분 ({(gm.gameTime.IsAM() ? "AM" : "PM")})";
        //Tostring()의 괄호 안에 "00"을 넣어주면 10의 자리까지 출력가능
        hpUI.text = gm.playerHP.ToString("00");
        //Hp 띄울거양잉 
    }
}
