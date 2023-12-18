using ConnectingDBToApp.MyDbContext;


namespace ConnectingDBToApp.GlobalClasses
{
    public static class DbContext
    {
        // Свойство контекста базы данных
        public static DataContext Tables { get; set; } = new DataContext();
    }
}
