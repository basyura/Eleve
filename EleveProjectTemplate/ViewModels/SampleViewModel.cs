using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace $safeprojectname$.ViewModels
{
    public class $safeprojectname$ViewModel : ViewModelBase
    {
        /// <summary></summary>
        private string _Message;
        public string Message
        {
            get { return _Message; }
            set
            {
                _Message = value;
                RaisePropertyChanged();
            }
        }
    }
}
