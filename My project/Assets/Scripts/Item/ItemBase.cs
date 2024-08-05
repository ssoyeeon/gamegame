using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;

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

        var pos = GetWorldPositon();

        foreach(var field in GameManager.instance.fields)
        {
            if(Vector3.Distance(field.transform.position, pos) <= 1.3f)
            {
                selectedField = field;
                break;
            }
        }

        if(selectedField == null)
        {
            foreach(var item in GameManager.instance.items)
            {
                if(Vector3.Distance(item.item.transform.position , pos) <= 1.3f)
                {
                    GameManager.instance.SelectItemByItemBase(this);
                    return;
                }
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

    private Vector3 GetWorldPositon()
    {
        Vector3 mousePoint = Input.mousePosition;                   // 마우스 위치를 가져옴
        Camera cam = Camera.main;                                   // 카메라는 메인 카메라
        mousePoint.z = cam.WorldToScreenPoint(gameObject.transform.position).z;
        return cam.ScreenToWorldPoint(mousePoint);
    }
}
