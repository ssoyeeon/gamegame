using System.Collections;
using System.Collections.Generic;
using UnityEditor.MemoryProfiler;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ItemController : MonoBehaviour
{
    public Field field;

    public void Hoe()                   //ȣ��
    {
        if(field.groundState == Field.GroundState.None && field.usedHoe == false)
        {
            field.usedHoe = true;
        }
    }

    public void WateringPot()           //���Ѹ���
    {
        if (field.groundState == Field.GroundState.Field && field.usedWateringPot == false)
        {
            field.usedWateringPot = true;
        }
    }

    public void Seed()                  //���ѽɱ�
    {
        if (field.groundState == Field.GroundState.Wet && field.isPlanted == false)
        {
            field.isPlanted = true;
        }
    }

    public void Sickle()                //��Ȯ�ϴ°� ������ ���淡 ���� ���̶�� �س���
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
