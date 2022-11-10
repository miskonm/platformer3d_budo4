using System;
using Services.Assets;
using UnityEngine;

namespace Services.UI
{
    public abstract class ScreenController
    {
        protected abstract Type ScreenType { get; }

        public abstract void Show();
        public abstract void Hide();

        protected virtual void OnShowBegin() { }
        protected virtual void OnShowEnd() { }
        protected virtual void OnHideBegin() { }
        protected virtual void OnHideEnd() { }
    }

    public abstract class ScreenController<TScreen> : ScreenController where TScreen : BaseScreen
    {
        private readonly IAssetsService _assetsService;

        protected TScreen Screen { get; private set; }

        protected sealed override Type ScreenType => typeof(TScreen);

        protected ScreenController(IAssetsService assetsService)
        {
            _assetsService = assetsService;
        }

        public sealed override void Show()
        {
            OnShowBegin();
            Screen.Show(); // Here we can add async
            OnShowEnd();
        }

        public sealed override void Hide()
        {
            OnHideBegin();
            Screen.Hide(); // Here we can add async
            OnHideEnd();
        }

        protected override void OnShowBegin()
        {
            if (Screen == null)
                CreateScreen();

            base.OnShowBegin();
        }

        private void CreateScreen()
        {
            TScreen prefab = _assetsService.Load<TScreen>(ScreenPath());
            if (prefab == null)
            {
                Debug.LogError($"Can't load prefab for type '{typeof(TScreen)}' from resources.");
                return;
            }

            Screen = UnityEngine.Object.Instantiate(prefab);
        }

        private string ScreenPath() =>
            $"Screen/{ScreenType.Name}";
    }
}