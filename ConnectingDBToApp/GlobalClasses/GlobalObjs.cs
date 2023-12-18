using System.Windows.Controls;
using System.Windows.Controls.Primitives;


namespace ConnectingDBToApp.GlobalClasses
{
    public static class GlobalObjs
    {
        // Объект рамки приложения 
        public static Frame MainFrame { get; set; } = null!;

        // Объект бокового меню приложения
        public static ListBox SideBar { get; set; } = null!;

        // Объект главной полосы прокрутки приложения 
        public static ScrollViewer MainScrollViewer { get; set; } = null!;

        // Объект кнопки, показывающая и скрывающая боковое меню приложения  
        public static ToggleButton MenuButton { get; set; } = null!;

        // Объект управления вкладками в разделе SSMS 
        public static TabControl SMMSTabControl { get; set; } = null!;

        // Объект управления вкладками в подразделе "Работа с SqlClient" в разделе SSMS  
        public static TabControl SMMSSubTabControl { get; set; } = null!;

        // Объект управления вкладками в разделе SQLite  
        public static TabControl SQLiteTabControl { get; set; } = null!;
    }
}
