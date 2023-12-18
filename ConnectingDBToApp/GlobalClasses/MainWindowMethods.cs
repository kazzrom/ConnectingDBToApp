using System;


namespace ConnectingDBToApp.GlobalClasses
{
    public static class MainWindowMethods
    {
        // Делегат функции сворачивания главного окна приложения
        public static Action? Minimize { get; set; }
        // Делегат функции закрытия главного окна приложения
        public static Action? Close { get; set; }
        // Делегат функции оконного/полного режима главного окна приложения
        public static Action? FullScreen { get; set; }
    }
}
