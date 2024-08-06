using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;

public class SeedItem : ItemBase
{
    public CropData cropData;
    public int amount;

    public override void Start()
    {
        hotKeyIndex = 100;
        base.Start();
    }

    public override void UseItem()
    {
        base.UseItem();

        if(selectedField.groundState != GroundState.Plowed)
        {
            selectedField = null;
            return;
        }

        selectedField.PlantSeed(cropData);
        amount--;

        if (amount == 0)
        {
            GameManager.instance.selectedItem = null;
            itemType = ItemType.None;
        }
    }
}
