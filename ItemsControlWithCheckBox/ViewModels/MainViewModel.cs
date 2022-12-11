using ItemsControlWithCheckBox.Interfaces;
using ItemsControlWithCheckBox.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ItemsControlWithCheckBox.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private ObservableCollection<ISelectableItem> _people;

        public MainViewModel()
        {
            People = new ObservableCollection<ISelectableItem>()
            {
                new PersonItemViewModel(new Person() { Name = "Ivan" }) ,
                new PersonItemViewModel(new Person() { Name = "Angela" }) ,
                new PersonItemViewModel(new Person() { Name = "Matilde" })
            };

            foreach (var person in People)
            {
                person.SelectionChanged += OnPersonSelectionChanged;
            }
        }

        public ObservableCollection<ISelectableItem> People
        {
            get
            {
                return _people;
            }
            set
            {
                SetProperty(ref _people, value);
            }
        }

        private void OnPersonSelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Selected items: " + People.Count(p => p.IsSelected));
        }
    }
}
