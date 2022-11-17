using Cysharp.Threading.Tasks;

namespace Services.Location
{
    public interface ILocationService
    {
        bool IsValid { get; }
        Coords Coords { get; } 
        
        UniTask BootstrapAsync();
    }
}