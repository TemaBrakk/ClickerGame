using UnityEngine;

[CreateAssetMenu(fileName = "StartShopModelStats", menuName = "ScriptableObjects/StartShopModelStats")]
public class StartShopModelStats : ScriptableObject
{
    public float ClickPowerUpgradeCost = 10f;
    public int ClickPowerNextLevel = 1;
    public float PassiveIncomeUpgradeCost = 10f;
    public int PassiveIncomeNextLevel = 1;
    public float PassiveIncomeIntervalUpgradeCost = 100f;
    public int PassiveIncomeIntervalNextLevel = 1;

    public bool IsShopWindowActive = false;
}
