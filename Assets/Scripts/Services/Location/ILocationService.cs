using System;

namespace Services.Location
{
    public interface ILocationService
    {
        bool IsValid { get; }
        Coords Coords { get; } 
        
        void Bootstrap(Action completeCallback = null);
    }
}