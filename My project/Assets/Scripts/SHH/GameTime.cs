using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameTime
{
    private int minute;
    private int hour;
    private int day;
    private bool is24Format;

    public GameTime(int minute, int hour, bool is24)
    {
        this.minute = minute;
        this.hour = hour;
        this.day = 0;
        this.is24Format = is24;
    }

    public bool AddMinutes(int amount)
    {
        minute += amount;

        if(minute >= 60)
        {
            minute -= 60;
            hour += 1;
        }

        if(hour >= 14)
        {
            ChangeDate();
            return true;
        }
        return false;
    }

    public void ChangeDate()
    {
        hour = 6;
        minute = 0;
        day++;
    }

    public int GetHour()
    {
        if(is24Format)
        {
            return hour;
        }

        if (hour > 12)
        {
            return hour - 12;
        }

        return hour;
    }

    public int GetMinute()
    {
        return minute;
    }

    public int GetDay()
    {
        return day;
    }
    public bool IsAM()
    {
        if(hour >= 12)
        {
            return false;
        }
        return true;
    }
}

