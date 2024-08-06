using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;

public class ToolItem : ItemBase
{
    public ToolType toolType;
    private int hpDecrease;
    public override void Start()
    {
        if(toolType == ToolType.Hoe)
        {
            hotKeyIndex = 0;
        }
        else if(toolType == ToolType.WateringPot)
        {
            hotKeyIndex = 1;
        }
        else if(toolType == ToolType.Sickle)
        {
            hotKeyIndex = 2;
        }
        base.Start();
    }

    public override void UseItem()
    {
        base.UseItem();

        if (selectedField == null)
        {
            return;
        }
        

        if(toolType == ToolType.None)
        {
            return;
        }

        if(toolType == ToolType.Hoe)
        {
            if(selectedField.groundState == GroundState.Planted)
            {
                return;
            }

            selectedField.groundState = GroundState.Plowed;
            return;
        }

        if(toolType == ToolType.Sickle)
        {
            if(selectedField.groundState == GroundState.Planted)
            {
                if (selectedField.CanHarvest())
                {
                    selectedField.Harvest();
                }
                else
                {
                    return;
                }
            }
        }
    }
}
