using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;             //게임매니저 인스턴스화

    public UIStorage UI;

    public bool activate = true;                    //행동 가능한지 상태를 나타내는 bool 값
    public bool isGrabbed = false;                  //아이템을 들고 있는지 체크하는 변수
    public int playerHP = 0;

    public GameTime gameTime = new GameTime(0, 2, true);
    public GameSpeed gameSpeed = GameSpeed.Default;
    public Timer timeScaleConvertTimer = new Timer(5f);

    public List<HotKeyData> items = new List<HotKeyData>();
    public List<Field> fields = new List<Field>();
    public ItemBase selectedItem;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        UI = FindObjectOfType<UIStorage>();
        timeScaleConvertTimer.Start();
        PrintTime();
    }
    void Update()
    {
        float deltaTime = Time.deltaTime;

        if(gameSpeed != GameSpeed.Pause)
        {
            if(timeScaleConvertTimer != null)
            {
                timeScaleConvertTimer.Update(deltaTime, gameSpeed);

                if (!timeScaleConvertTimer.IsRunning())                   // 타이머가 실행중이지 않을 때
                {
                    var isDayChange = gameTime.AddMinutes(10);

                    if (isDayChange)
                    {
                        if(fields != null)
                        {
                            foreach (var field in fields)
                            {
                                field.GrowPlant();
                            }
                        }
                    }
                    else
                    {
                        timeScaleConvertTimer.Start();
                    }

                    PrintTime();
                }
            }

            if(Input.GetKeyDown(KeyCode.Q))
            {
                SelectItemByIndex(0);
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                SelectItemByIndex(1);
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SelectItemByIndex(2);
            }
        }
    }
    
    public void SelectItemByIndex(int index)
    {
        for(int i = 0; i < items.Count; i ++)
        {
            if (items[i].indexNum == index)
            {
                if(selectedItem != null)
                {
                    selectedItem.DeSelectItem();
                }
                selectedItem = items[i].item;
                selectedItem.SelectItem();
                return;
            }
        }
    }
    public void SelectItemByItemBase(ItemBase itemBase)
    {
        if(!HasThisItem(itemBase))
        {
            return;
        }

        selectedItem = itemBase;
    }

    private bool HasThisItem(ItemBase itemBase)
    {
        foreach(var item in items)
        {
            if (item.item == itemBase)
            {
                return true;
            }
        }
        return false;
    }

    private void PrintTime()
    {
        string timeText = $"{((gameTime.GetDay() == 0) ? "" : gameTime.GetDay().ToString() + "일차")} " +
            $"{gameTime.GetHour()}시 {gameTime.GetMinute()}분 ({(gameTime.IsAM() ? "AM" : "PM")})";

        if(UI == null)
        {
            return;
        }

        if(UI.GetText("Time") != null)
        {
            UI.GetText("Time").text = timeText;
        }
    }
}

