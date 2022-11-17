using Cysharp.Threading.Tasks;

namespace Services.Location
{
    /// <summary>
    /// This is fake service for Minsk location.
    /// </summary>
    public class FakeLocationService : ILocationService
    {
        private const string Tag = nameof(FakeLocationService);
        
        public bool IsValid { get; private set; }
        public Coords Coords { get; private set; }
        
        public async UniTask BootstrapAsync()
        {
            IsValid = true;
            Coords = new Coords(53.904541f, 27.561523f);
            await UniTask.CompletedTask;
        }
    }
}