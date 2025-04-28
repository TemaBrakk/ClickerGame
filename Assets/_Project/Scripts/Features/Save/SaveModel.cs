public class SaveModel
{
    public SaveData MainSaveData { get; private set; }
    public SaveData FirstSaveSlotData { get; private set; }
    public SaveData SecondSaveSlotData { get; private set; }
    public SaveData ThirdSaveSlotData { get; private set; }

    public void Initialize()
    {

    }

    public void SetMainSaveData(SaveData data)
    {
        MainSaveData = data;
    }

    public void SetFirstSaveSlotData(SaveData data)
    {
        FirstSaveSlotData = data;
    }

    public void SetSecondSaveSlotData(SaveData data)
    {
        SecondSaveSlotData = data;
    }

    public void SetThirdSaveSlotData(SaveData data)
    {
        ThirdSaveSlotData = data;
    }
}
