using ConnectingDBToApp.MyDbContext;


namespace ConnectingDBToApp.GlobalClasses
{
    public static class DbContext
    {
        public static DataContext Tables { get; set; } = new DataContext();
    }
}
