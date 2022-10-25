using Services.Persistence;

namespace Services.Save
{
    public interface ISaveLoadDataPiece : ILoadDataPiece
    {
        void Save(PersistenceData data);
    }
}