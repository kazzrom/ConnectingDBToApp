using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

using ConnectingDBToApp.Models;


namespace ConnectingDBToApp.GlobalClasses
{
    public class CustomStyleSelector : StyleSelector
    {
        public Style PlainTextItem { get; set; } = null!;
        public Style H1Item { get; set; } = null!;
        public Style H2Item { get; set; } = null!;
        public Style ImageItem { get; set; } = null!;
        public Style DoubleImageItem { get; set; } = null!;
        public Style CopyButtonItem { get; set; } = null!;
        public Style CodeImageItem { get; set; } = null!;
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
