using Zenject;

namespace Services.UI
{
    public class UiFactory
    {
        private readonly IInstantiator _instantiator;

        public UiFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T Create<T>() where T : ScreenController =>
            _instantiator.Instantiate<T>();
    }
}