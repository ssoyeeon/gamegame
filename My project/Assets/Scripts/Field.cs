using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameUtil;

public class Field : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;                   // �� ������Ʈ�� ��������Ʈ
    public GroundState groundState = GroundState.Empty;     // ���� ����

    public CropData cropData;                               // �۹��� ������

    public float moistureLevel;             // ����
    public int growLevel;                   // ���� �ܰ�

    public void Start()
    {
        if(spriteRenderer == null)
        {
            if (!TryGetComponent <SpriteRenderer>(out spriteRenderer))
            {
                spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
            }
        }
        GameManager.instance.fields.Add(this);
    }
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, Vector3.one);
    }

    public void PlantSeed(CropData crop)
    {
        cropData = crop;
        spriteRenderer.sprite = cropData.cropSprite;
    }

    public void GrowPlant()
    {
        if(groundState != GroundState.Plowed)
        {
            return;
        }

        growLevel++;

        if(growLevel >= cropData.cropMidGrowthDay)
        {
            if (growLevel >= cropData.cropGrowthPeriod)
            {
                spriteRenderer.sprite = cropData.cropMaxGrowthSprite;

                growLevel = cropData.cropGrowthPeriod;
            }
            else
            {
                spriteRenderer.sprite = cropData.cropMidGrowthSprite;
            }
        }
    }

    public void Harvest()
    {
        GameManager.instance.money += cropData.cropSellPrice;

        cropData = null;
        spriteRenderer.sprite = null;
        groundState = GroundState.Empty;
        growLevel = 0;
    }

    public bool CanHarvest()
    {
        if(growLevel >= cropData.cropGrowthPeriod)
        {
            return true;
        }

        return false;
    }
}
