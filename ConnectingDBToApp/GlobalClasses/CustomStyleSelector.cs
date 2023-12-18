using System.Windows;
using System.Windows.Controls;

using ConnectingDBToApp.Models;


namespace ConnectingDBToApp.GlobalClasses
{
    public class CustomStyleSelector : StyleSelector
    {
        // Стиль для обычного текста
        public Style PlainTextItem { get; set; } = null!;
        // Стиль для заголовка первого уровня
        public Style H1Item { get; set; } = null!;
        // Стиль для заголовка второго уровня
        public Style H2Item { get; set; } = null!;
        // Стиль для изображения
        public Style ImageItem { get; set; } = null!;
        // Стиль для двух изображений вместе
        public Style DoubleImageItem { get; set; } = null!;
        // Стиль для кнопки копирования текста
        public Style CopyButtonItem { get; set; } = null!;
        // Стиль для изображения с программным кодом
        public Style CodeImageItem { get; set; } = null!;
        // Стиль для гиперссылки
        public Style HyperLinkItem { get; set; } = null!;

        public override Style SelectStyle(object item, DependencyObject container)
        {
            var elementItem = (ElementItem)item;

            switch (elementItem.ObjectType)
            {
                case "H1":
                    return H1Item;
                case "H2":
                    return H2Item;
                case "Image":
                    return ImageItem;
                case "DoubleImage":
                    return DoubleImageItem;
                case "CopyButton":
                    return CopyButtonItem;
                case "CodeImage":
                    return CodeImageItem;
                case "HyperLink":
                    return HyperLinkItem;
                default:
                    return PlainTextItem;
            }
        }

    }
}
