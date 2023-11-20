namespace ConnectingDBToApp.Models
{
    public interface ElementItem
    {
        public long Id { get; set; }

        public string ObjectType { get; set; }

        public string Chapter { get; set; }

        public string Text { get; set; }

        public string? AdditionalText { get; set; }

        public string? Code { get; set; }
    }
}
