public interface ISaveable
{
    void SavebleRegister();

    GameSaveData GenerateSaveData(GameSaveData saveData);

    void RestoreGameData(GameSaveData saveData);
}
