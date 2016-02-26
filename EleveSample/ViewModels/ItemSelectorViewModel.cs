using Eleve;

namespace EleveSample.ViewModels
{
    public class ItemSelectorViewModel : ViewModelBase
    {
        /// <summary>
        /// 
        /// </summary>
        private string _ID;
        public string ID {
            get { return _ID; }
            set { _ID = value;
                  RaisePropertyChanged();
            }
        }
    }
}
