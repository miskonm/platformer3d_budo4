using UnityEngine;
using Zenject;

namespace Services.Location
{
    public class LocationServiceInstaller : Installer<LocationServiceInstaller>
    {
        public override void InstallBindings()
        {
            if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
            {
                Container.Bind<ILocationService>().To<UnityLocationService>().AsSingle();
            }
            else
            {
                Container.Bind<ILocationService>().To<FakeLocationService>().AsSingle();
            }
        }
    }
}