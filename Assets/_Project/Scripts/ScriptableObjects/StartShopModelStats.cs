using UnityEngine;

[CreateAssetMenu(fileName = "StartShopModelStats", menuName = "ScriptableObjects/StartShopModelStats")]
public class StartShopModelStats : ScriptableObject
{
    public float ClickPowerUpgradeCost = 0f;
    public int ClickPowerNextLevel = 1;
    public float PassiveIncomeUpgradeCost = 10f;
    public int PassiveIncomeNextLevel = 1;

    public bool IsShopWindowActive = false;
}
