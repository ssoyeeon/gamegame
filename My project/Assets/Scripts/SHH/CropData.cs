using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/CropData")]
public class CropData : ScriptableObject
{
    [Header("�۹� �̸�")] public string cropName;           // �۹��� �̸�
    [Header("Ư¡")] public string cropFeatures;              // �۹��� Ư¡

    [Header("�ڶ�� �Ⱓ")] public float cropGrowthPeriod;       // �۹��� �ڶ�� �Ⱓ
    [Header("�߰� ����")] public float cropMidGrowthDay;        // �۹��� �߰� ���� �Ⱓ(������ ����)

    [Header("���� �ݾ�")] public int cropBuyPrice;          // �۹��� ���� ����
    [Header("�Ǹ� �ݾ�")] public int cropSellPrice;         // �۹��� �Ǹ� ����

    [Header("�۹� �̹���")] public Sprite cropSprite;        // �۹��� �̹���

}
