using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;             //게임매니저 인스턴스화

    public UIStorage UI;

    public int money = 500;
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

            if (Input.GetMouseButtonDown(0))
            {
                if (selectedItem != null)
                {
                    selectedItem.UseItem();
                }
                else
                {
                    SelectItemByItemBase(GetItem());
                }
            }

            if(Input.GetMouseButtonDown(1))
            {
                if(selectedItem  != null) 
                {
                    ChangeHotKeyData(GetItem());
                }
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

        if (selectedItem != null)
        {
            selectedItem.DeSelectItem();
        }
        selectedItem = itemBase;

        selectedItem.SelectItem();
    }

    private HotKeyData GetHotKeyData(ItemBase itemBase)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i].item == itemBase)
            {
                return items[i];
            }
        }

        return null;
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

    private void ChangeHotKeyData(ItemBase itemBase)
    {
        if (itemBase == null) return;
        if (selectedItem == itemBase) return;
        if (selectedItem.GetType() == typeof(ToolItem) || selectedItem.GetType() == typeof(ToolItem)) return;

        HotKeyData selectedHotKeyData = GetHotKeyData(selectedItem);
        HotKeyData hotKeyData = GetHotKeyData(itemBase);

        int selectedIndex = selectedHotKeyData.indexNum;

        selectedHotKeyData.indexNum = hotKeyData.indexNum;

        hotKeyData.indexNum = selectedIndex;
    }
    public Field GetField()
    {
        var pos = GetWorldPositon();

        float lastDistance = 1;
        Field field = null;

        foreach (var _field in GameManager.instance.fields)
        {
            var fieldPosition = new Vector3(_field.transform.position.x, _field.transform.position.y, 0);

            if (lastDistance > Vector3.Distance(_field.transform.position, pos))
            {
                lastDistance = Vector3.Distance(_field.transform.position, pos);
                field = _field;
            }
        }

        return field;
    }

    public ItemBase GetItem()
    {
        var pos = GetWorldPositon();

        float lastDistance = 1;
        ItemBase itemBase = null;

        foreach (var item in GameManager.instance.items)
        {
            var itemPosition = new Vector3(item.item.transform.position.x, item.item.transform.position.y, 0);

            if (lastDistance > Vector3.Distance(itemPosition, pos))
            {
                lastDistance = Vector3.Distance(itemPosition, pos);
                itemBase = item.item;
            }
        }

        return itemBase;
    }
    public Vector3 GetWorldPositon()
    {
        Vector3 mousePoint = Input.mousePosition;                   // 마우스 위치를 가져옴
        Camera cam = Camera.main;                                   // 카메라는 메인 카메라
        mousePoint.z = cam.WorldToScreenPoint(gameObject.transform.position).z;
        return cam.ScreenToWorldPoint(mousePoint);
    }
}

