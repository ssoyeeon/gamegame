using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameUtil
{
    [System.Serializable]
    public class HotKeyData
    {
        public int indexNum;
        public ItemBase item;

        public HotKeyData(int @indexNum, ItemBase @itemBase)
        {
            this.indexNum = @indexNum;
            this.item = @itemBase;
        }
    }
    public enum GameSpeed       // ������ �ӵ�
    {
        Pause = 0,
        Default,                // 1���
        Slow,                   // 0.5���
        Fast                    // 2���
    }

    public enum ItemType
    {
        None,                   // �ƹ��͵� �ƴ�
        Tool,                   // ����
        Seed                    // ����
    }

    public enum ToolType
    {
        None,                   // ����
        Hoe,                    // ȣ��
        WateringPot,            // ���Ѹ���
        Sickle,                 // ��(?)
        Shovel                  // ��
    }
    public enum GroundState            //���� ���� ����
    {
        None,                   // �ƹ��͵� �ƴ�
        Empty,                  // ����ִ� ����
        Plowed,                 // ���� ���Ƶ� ����
        Planted                 // �ɰ�������
    }
}

