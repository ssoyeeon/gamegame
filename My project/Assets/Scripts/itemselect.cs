using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemselect : MonoBehaviour
{
    //��Ŭ�� ��Ŭ���ϸ� ��Ȯ�ϱ�
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("������ �ɾ����ϴ�");
        }
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("�۹��� ��Ȯ�߽��ϴ�");
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log("ȣ�̰� ���õǾ����ϴ�");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log("���Ѹ����� ���õǾ����ϴ�");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("E key pressed");
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("R key pressed");
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("D key pressed");
        }
        else if(Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("F key pressed");
        }
    }
}
