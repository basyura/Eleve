﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.ViewModels
{
    public class EleveSampleViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        public volatile int Counter = 0;
        /// <summary>
        /// 
        /// </summary>
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set {
                _Message = value;
                RaisePropertyChanged();
            }
        }
    }
}
