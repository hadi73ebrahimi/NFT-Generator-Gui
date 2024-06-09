using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftGeneratorGui.ViewModels
{
    public class CustomListBoxItem
    {
        public string Text { get; set; }
        public object Tag { get; set; }

        public CustomListBoxItem(string text, object tag)
        {
            Text = text;
            Tag = tag;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}
