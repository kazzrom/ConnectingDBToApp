using ConnectingDBToApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace ConnectingDBToApp.GlobalClasses
{
    public class CustomStyleSelector : StyleSelector
    {
        public Style PlainTextItem { get; set; }
        public Style H1Item { get; set; }
        public Style H2Item { get; set; }
        public Style ImageItem { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            var elementItem = (SsmsElement)item;

            switch (elementItem.ObjectType)
            {
                case "H1":
                    return H1Item;
                case "H2":
                    return H2Item;
                case "Image":
                    return ImageItem;
                default:
                    return PlainTextItem;
            }
        }

    }
}
