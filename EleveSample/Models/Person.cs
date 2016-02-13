using Eleve;

namespace EleveSample.Models
{
    public class Person : NotificationObject
    {
        /// <summary>
        /// 
        /// </summary>
        private long _ID;
        public long ID {
            get { return _ID; }
            set { _ID = value;
                  RaisePropertyChanged();
            }
        }
        /// <summary>
        /// 
        /// </summary>
        private string _Name;
        public string Name {
            get { return _Name; }
            set { _Name = value; 
                  RaisePropertyChanged();
            }
        }
    }
}
