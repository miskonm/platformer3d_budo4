using Services.Persistence;

namespace Services.Save
{
    public interface ILoadDataPiece
    {
        void Load(PersistenceData data);
    }
}