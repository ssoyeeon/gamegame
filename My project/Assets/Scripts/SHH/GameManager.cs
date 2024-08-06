using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;
using static UnityEditor.PlayerSettings;
using static UnityEditor.Progress;

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
                if (GameManager.instance.selectedItem != null)
                {
                    selectedItem.UseItem();
                }
                else
                {
                    SelectItemByItemBase(GetItem());
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
    public Field GetField()
    {
        var pos = GetWorldPositon();

        foreach (var field in GameManager.instance.fields)
        {
            var fieldPosition = new Vector3(field.transform.position.x, field.transform.position.y, 0);

            if (Vector3.Distance(field.transform.position, pos) <= 0.9f)
            {
                return field;
            }
        }

        return null;
    }

    public ItemBase GetItem()
    {
        var pos = GetWorldPositon();

        foreach (var item in GameManager.instance.items)
        {
            var itemPosition = new Vector3(item.item.transform.position.x, item.item.transform.position.y, 0);
            if (Vector3.Distance(itemPosition, pos) <= 0.9f)
            {
                return item.item;
            }
        }

        return null;
    }
    public Vector3 GetWorldPositon()
    {
        Vector3 mousePoint = Input.mousePosition;                   // 마우스 위치를 가져옴
        Camera cam = Camera.main;                                   // 카메라는 메인 카메라
        mousePoint.z = cam.WorldToScreenPoint(gameObject.transform.position).z;
        Debug.Log($"{cam.ScreenToWorldPoint(mousePoint).x}, {cam.ScreenToWorldPoint(mousePoint).y}, {cam.ScreenToWorldPoint(mousePoint).z}");
        return cam.ScreenToWorldPoint(mousePoint);
    }
}

