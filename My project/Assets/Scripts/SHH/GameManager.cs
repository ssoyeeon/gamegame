using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;             //���ӸŴ��� �ν��Ͻ�ȭ

    public UIStorage UI;

    public bool activate = true;                    //�ൿ �������� ���¸� ��Ÿ���� bool ��
    public bool isGrabbed = false;                  //�������� ��� �ִ��� üũ�ϴ� ����
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

                if (!timeScaleConvertTimer.IsRunning())                   // Ÿ�̸Ӱ� ���������� ���� ��
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
        string timeText = $"{((gameTime.GetDay() == 0) ? "" : gameTime.GetDay().ToString() + "����")} " +
            $"{gameTime.GetHour()}�� {gameTime.GetMinute()}�� ({(gameTime.IsAM() ? "AM" : "PM")})";

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

