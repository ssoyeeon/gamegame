using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public enum GroundState            //현재 땅의 상태
    {
        None,
        Field,
        Wet,
        Planted


    }
    public bool usedHoe = false;                        //호미를 사용했는지 체크하는 변수
    public bool usedWateringPot = false;                //물뿌리개를 사용했는지 체크하는 변수
    public bool isPlanted = false;                      //씨앗을 심었는지 체크하는 변수
    public bool isReaped = false;                         //수확했는지 체크하는 변수                      

    public GroundState groundState;

    public void Update()
    {
        switch (groundState)    //땅의 상태를 변경해주는 스위치 문
        {
            case GroundState.None:
                if(usedHoe == true)
                {
                    groundState = GroundState.Field;
                }
                break;

            case GroundState.Field:
                if (usedWateringPot == true)
                {
                    groundState = GroundState.Wet;
                }
                 break;

            case GroundState.Wet:
                if(isPlanted == true)
                {
                    groundState = GroundState.Planted;
                }    
                break;

            case GroundState.Planted:
                if(isReaped == true)
                {
                    groundState = GroundState.None;
                }
                break;

        }

    }

}
