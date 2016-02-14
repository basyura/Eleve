using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;
using Eleve.ProjectTemplate.Models;

namespace Eleve.ProjectTemplate.ViewModels
{
    public class ProjectNameViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        private SampleMessage _SampleMessage;
        public SampleMessage SampleMessage {
            get { return _SampleMessage; }
            set { _SampleMessage = value;
                  RaisePropertyChanged();
            }
        }
    }
}
