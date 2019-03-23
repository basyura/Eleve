﻿using System.Collections.ObjectModel;
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
            set { _Message = value;
                  RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private Visibility _PersonVisibility = Visibility.Collapsed;
        public Visibility PersonVisibility {
            get { return _PersonVisibility; }
            set { _PersonVisibility = value;
                  RaisePropertyChanged(); 
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private ObservableCollection<Person> _Persons;
        public ObservableCollection<Person> Persons {
            get { return _Persons; }
            set { _Persons = value;
                  RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public long _SelectedPersonID;
        public long SelectedPersonID {
            get { return _SelectedPersonID; }
            set { _SelectedPersonID = value;
                  RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        public string _SelectedPersonName;
        public string SelectedPersonName {
            get { return _SelectedPersonName; }
            set { _SelectedPersonName = value;
                  RaisePropertyChanged();
            }
        }
    }
}
