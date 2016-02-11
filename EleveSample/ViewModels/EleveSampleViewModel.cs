using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.ViewModels
{
    public class EleveSampleViewModel : ViewModelBase
    {
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
