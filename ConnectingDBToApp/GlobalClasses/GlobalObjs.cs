using System.Windows.Controls;
using System.Windows.Controls.Primitives;

using ConnectingDBToApp.Models;


namespace ConnectingDBToApp.GlobalClasses
{
    public static class GlobalObjs
    {
        public static Frame MainFrame { get; set; } = null!;
        public static ListBox SideBar { get; set; } = null!;
        public static ScrollViewer MainScrollViewer { get; set; } = null!;
        public static Button SideBarButton { get; set; } = null!;
        public static ToggleButton MenuButton { get; set; } = null!;
        public static TabControl SMMSTabControl { get; set; } = null!;
        public static TabControl SMMSSubTabControl { get; set; } = null!;
        public static TabControl SQLiteTabControl { get; set; } = null!;
    }
}
