using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ItemController : MonoBehaviour
{
    public Field field;

    public void Hoe()                   //호미
    {
        if(field.groundState == Field.GroundState.None && field.usedHoe == false)
        {
            field.usedHoe = true;
        }
    }

    public void WateringPot()           //물뿌리개
    {
        if (field.groundState == Field.GroundState.Field && field.usedWateringPot == false)
        {
            field.usedWateringPot = true;
        }
    }

    public void Seed()                  //씨앗심기
    {
        if (field.groundState == Field.GroundState.Wet && field.isPlanted == false)
        {
            field.isPlanted = true;
        }
    }

    public void Sickle()                //수확하는거 도구가 없길래 대충 낫이라고 해놓음
    {
        if (field.groundState == Field.GroundState.Planted && field.isReaped == false)
        {
            field.isReaped = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
