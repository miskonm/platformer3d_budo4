namespace Services.UI
{
    public interface IUiService
    {
        T GetController<T>() where T : ScreenController;

        void ShowScreen<T>() where T : ScreenController;
        void HideScreen<T>() where T : ScreenController;
    }
}