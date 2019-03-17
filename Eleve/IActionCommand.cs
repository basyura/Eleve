using System;
using System.Threading.Tasks;

namespace Eleve
{
    public interface IActionCommand
    {
        void Initialize(ViewModelBase viewModel);
        /// <summary>
        /// 
        /// </summary>
        Task<ActionResult> Execute(object sender, EventArgs evnt, object parameter);
    }
}
