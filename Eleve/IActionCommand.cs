using System;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eleve
{
    public interface IActionCommand
    {
        void Initialize(ViewModelBase viewModel);
        /// <summary>
        /// 
        /// </summary>
        void Execute(object sender, EventArgs evnt, object parameter);
    }
}
