using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFConvertor.Models;

namespace WPFConvertor.ViewModels
{
    public class MainViewModel : Window
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // This method is called by the Set accessor of each property.
        // The CallerMemberName attribute that is applied to the optional propertyName
        // parameter causes the property name of the caller to be substituted as an argument.
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private ObservableCollection<Person> _people;

        public ObservableCollection<Person> People
        {
            get { return _people; }

            set
            {
                _people = value;
                NotifyPropertyChanged();
            }
        }

        public MainViewModel()
        {
            People = new ObservableCollection<Person>();
            for (int x = 1; x < 101; x++)
            {
                var newPerson = new Person() { id = x, Name = $"Name{x}" };
                People.Add(newPerson);
            }
        }

    }
}
