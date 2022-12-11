using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsControlWithCheckBox.Interfaces
{
    public interface ISelectableItem
    {
        event EventHandler SelectionChanged;

        string Text { get; set; }
        bool IsSelected { get; set; }
        bool IsEnabled { get; set; }
    }
}
