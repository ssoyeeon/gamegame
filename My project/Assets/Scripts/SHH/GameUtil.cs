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
    public enum GameSpeed       // 게임의 속도
    {
        Pause = 0,
        Default,                // 1배속
        Slow,                   // 0.5배속
        Fast                    // 2배속
    }

    public enum ItemType
    {
        None,                   // 아무것도 아님
        Tool,                   // 도구
        Seed                    // 씨앗
    }

    public enum ToolType
    {
        None,                   // 없음
        Hoe,                    // 호미
        WateringPot,            // 물뿌리개
        Sickle,                 // 낫(?)
        Shovel                  // 삽
    }
    public enum GroundState            //현재 땅의 상태
    {
        None,                   // 아무것도 아님
        Empty,                  // 비어있는 상태
        Plowed,                 // 밭을 갈아둔 상태
        Planted                 // 심겨져있음
    }
}

