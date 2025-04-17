using UnityEngine;

[CreateAssetMenu(fileName = "StartGameModelStats", menuName = "ScriptableObjects/StartGameModelStats")]
public class StartGameModelStats : ScriptableObject
{
    public float Coins = 0f;

    public float ClickPower = 1f;
    public float PassiveIncome = 0f;
    public float PassiveIncomeInterval = 1f;

    public float ClickPowerBonus = 1f;
    public float PassiveIncomeBonus = 0.5f;
    public float PassiveIncomeIntervalMultiplier = 0.9f;
}
