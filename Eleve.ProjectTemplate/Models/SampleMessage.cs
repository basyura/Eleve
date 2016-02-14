using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace Eleve.ProjectTemplate.Models
{
    public class SampleMessage : NotificationObject
    {
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
    }
}
