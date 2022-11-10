using Zenject;

namespace Services.Web
{
    public class HttpWebRequestInstaller : Installer<HttpWebRequestInstaller>
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IHttpWebRequestFactory>()
                .To<UnityHttpWebRequestFactory>()
                .FromNewComponentOnNewGameObject()
                .AsSingle();
        }
    }
}