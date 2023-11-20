using System;


namespace ConnectingDBToApp.GlobalClasses
{
    public static class MainWindowMethods
    {
        public static Action? Minimize { get; set; }
        public static Action? Close { get; set; }
        public static Action? FullScreen { get; set; }
    }
}
