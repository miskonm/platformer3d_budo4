namespace Services.Save
{
    public interface ISaveLoadService
    {
        void Save();
        void Load();
        void AddSaveLoadPiece(ISaveLoadDataPiece piece);
        void RemoveSaveLoadPiece(ISaveLoadDataPiece piece);
    }
}