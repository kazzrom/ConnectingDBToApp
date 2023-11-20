using ConnectingDBToApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace ConnectingDBToApp.GlobalClasses
{
    public static class GlobalObjs
    {
        public static Frame MainFrame { get; set; }
        public static ListBox SideBar { get; set; }
        public static Button SideBarButton { get; set; }
        public static ToggleButton MenuButton { get; set; }
        public static TestResult Result { get; set; } = new TestResult();
    }
}
