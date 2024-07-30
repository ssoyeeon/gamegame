using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemselect : MonoBehaviour
{ 
    //좌클릭 우클릭하면 수확하기
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("씨앗을 심었습니다")
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("작물을 수확했습니다")
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Hoe();
            Debug.Log("호미가 선택되었습니다");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            WateringPot();
            Debug.Log("물뿌리개가 선택되었습니다");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Seed();
            Debug.Log("E key pressed")
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Seed();
            Debug.Log("R key pressed");
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Seed();
            Debug.Log("D key pressed");
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            Seed();
            Debug.Log("F key pressed");
        }
    }
}
