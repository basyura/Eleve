using System.Collections.ObjectModel;
using System.Windows;
using Eleve;
using EleveSample.Models;

namespace EleveSample.ViewModels
{
    public class EleveSampleViewModel : ViewModelBase
    {
        /// <summary></summary>
        public bool IsTerminating = false;
        /// <summary></summary>
        public volatile int Counter = 0;
        /// <summary>
        /// 
        /// </summary>
        private string _Message;
        public string Message {
            get { return _Message; }
            set { SetProperty(ref _Message, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        private Visibility _PersonVisibility = Visibility.Collapsed;
        public Visibility PersonVisibility {
            get { return _PersonVisibility; }
            set { SetProperty(ref _PersonVisibility, value); }
        }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<Person> _Persons;
        public ObservableCollection<Person> Persons {
            get { return _Persons; }
            set { SetProperty(ref _Persons, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public long _SelectedPersonID;
        public long SelectedPersonID {
            get { return _SelectedPersonID; }
            set { SetProperty(ref _SelectedPersonID, value); }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _SelectedPersonName;
        public string SelectedPersonName {
            get { return _SelectedPersonName; }
            set { SetProperty(ref _SelectedPersonName, value); }
        }
    }
}
