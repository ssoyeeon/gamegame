using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;
using UnityEditorInternal.Profiling.Memory.Experimental;

[System.Serializable]
public class ItemBase : MonoBehaviour
{
    public int indexNum;
    public ItemType itemType;
    public SpriteRenderer spriteRenderer;
    protected int hotKeyIndex;

    protected Field selectedField;

    public virtual void Start()
    {
        if (spriteRenderer == null)
        {
            if (!TryGetComponent<SpriteRenderer>(out spriteRenderer))
            {
                spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            }
        }

        HotKeyData hotKeyData;

        if (hotKeyIndex == 100)
        {
            hotKeyData = new HotKeyData(indexNum, this);
        }
        else
        {
            hotKeyData = new HotKeyData(hotKeyIndex, this);
        }

        GameManager.instance.items.Add(hotKeyData);
    }
    public virtual void UseItem()
    {
        if(GameManager.instance.selectedItem == null)
        {
            return;
        }

        selectedField = GameManager.instance.GetField();

        if(selectedField == null)
        {
            ItemBase item = GameManager.instance.GetItem();

            if (item != null)
            {
                GameManager.instance.SelectItemByItemBase(item);
            }

            return;
        }
    }

    public void SelectItem()
    {
        spriteRenderer.color = Color.green;
    }

    public void DeSelectItem()
    {
        spriteRenderer.color = Color.white;
    }


}
