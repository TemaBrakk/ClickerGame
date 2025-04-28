using UnityEngine;

[CreateAssetMenu(fileName = "GameModelStats", menuName = "ScriptableObjects/GameModelStats")]
public class GameModelStats : ScriptableObject
{
    public float ClickPowerBonus = 1f;
    public float PassiveIncomeBonus = 0.5f;
    public float PassiveIncomeIntervalMultiplier = 0.9f;
}
