using ItemsControlWithCheckBox.Interfaces;
using ItemsControlWithCheckBox.Models;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItemsControlWithCheckBox.ViewModels
{
    public class PersonItemViewModel : BindableBase, ISelectableItem
    {
        private string text;
        private bool isSelected;
        private bool isEnabled;

        public event EventHandler SelectionChanged;

        public PersonItemViewModel(Person person)
        {
            Text = person.Name;
            IsEnabled = true;
        }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }
        
        public bool IsSelected
        {
            get => isSelected;
            set
            {
                if (isSelected != value)
                {
                    SetProperty(ref isSelected, value);
                    OnSelectionChanged();
                }
            }
        }
       
        public bool IsEnabled
        { 
            get => isEnabled;
            set => SetProperty(ref isEnabled, value);
        }

        private void OnSelectionChanged()
        {
            SelectionChanged?.Invoke(this, new EventArgs());
        }
    }
}
