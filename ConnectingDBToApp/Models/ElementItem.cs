namespace ConnectingDBToApp.Models
{
    public interface ElementItem
    {
        public int Id { get; set; }

        // Свойство с типом элемента (H1, H2, PlainText и т.д.)
        public string ObjectType { get; set; }

        // Свойство с названием раздела элемента
        public string Chapter { get; set; }

        // Свойство с текстом элемента (название элемента, путь к изображению)
        public string Text { get; set; }

        // Свойство с дополнительным текстом элемента (обычно содержит путь к изображения)
        public string? AdditionalText { get; set; }

        // Свойство с текстом программного кода или названием библиотеки для копирования в буфер обмена
        public string? Code { get; set; }
    }
}
