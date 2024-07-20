using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    public enum GroundState            //���� ���� ����
    {
        None,
        Field,
        Wet,
        Planted


    }
    public bool usedHoe = false;                        //ȣ�̸� ����ߴ��� üũ�ϴ� ����
    public bool usedWateringPot = false;                //���Ѹ����� ����ߴ��� üũ�ϴ� ����
    public bool isPlanted = false;                      //������ �ɾ����� üũ�ϴ� ����
    public bool isReaped = false;                         //��Ȯ�ߴ��� üũ�ϴ� ����                      

    public GroundState groundState;

    public void Update()
    {
        switch (groundState)    //���� ���¸� �������ִ� ����ġ ��
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
