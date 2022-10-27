namespace Services.Persistence
{
    public interface IPersistenceService
    {
        PersistenceData Data { get; }
        
        void Bootstrap();
        void Save();
    }
}