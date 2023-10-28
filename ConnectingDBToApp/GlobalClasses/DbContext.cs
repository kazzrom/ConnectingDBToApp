using ConnectingDBToApp.MyDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectingDBToApp.GlobalClasses
{
    public static class DbContext
    {
        public static DataContext Tables { get; set; } = new DataContext();
    }
}
