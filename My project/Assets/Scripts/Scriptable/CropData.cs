using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/CropData")]
public class CropData : ScriptableObject
{
    [Header("작물 이름")] public string cropName;           // 작물의 이름
    [Header("특징")] public string cropFeatures;              // 작물의 특징

    [Header("자라는 기간")] public int cropGrowthPeriod;       // 작물이 자라는 기간
    [Header("중간 성장")] public int cropMidGrowthDay;        // 작물의 중간 성장 기간(디자인 변경)

    [Header("구매 금액")] public int cropBuyPrice;          // 작물의 구매 가격
    [Header("판매 금액")] public int cropSellPrice;         // 작물의 판매 가격

    [Header("작물 이미지")] public Sprite cropSprite;        // 작물의 이미지
    [Header("중간 이미지")] public Sprite cropMidGrowthSprite;        // 작물의 이미지
    [Header("최종 이미지")] public Sprite cropMaxGrowthSprite;        // 작물의 이미지

}
