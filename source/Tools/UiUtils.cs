using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NftGeneratorGui.Tools
{
    public class UiUtils
    {
        public static void ShiftListBoxItem(ListBox listBox, int direction)
        {
            // Check if an item is selected
            if (listBox.SelectedIndex == -1)
            {
                return;
            }

            // Calculate the new index of the selected item
            int newIndex = listBox.SelectedIndex + direction;

            // Check if the new index is within the bounds of the ListBox
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
            {
                return;
            }

            // Get the selected item and remove it from the ListBox
            object selectedItem = listBox.SelectedItem;
            listBox.Items.Remove(selectedItem);

            // Insert the selected item at the new index in the ListBox
            listBox.Items.Insert(newIndex, selectedItem);

            // Select the moved item
            listBox.SetSelected(newIndex, true);
        }

        public static bool IsValidInt(string value)
        {
            int finalvalue;
            var isvalid = int.TryParse(value, out finalvalue);
            return isvalid;
        }
    }
}
