using System;
using System.Threading.Tasks;
using System.Windows.Controls;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Compute : EleveSampleActionBase
    {
        /// <summary>
        /// MVVM でもできるんだけど，恐れずに View にアクセスするサンプル。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="parameter"></param>
        public override Task<ActionResult> Execute(object sender, EventArgs args, object parameter)
        {
            if (!decimal.TryParse(GetElement<TextBox>("ComputeA").Text, out decimal arga))
            {
                return SuccessTask;
            }

            if (!decimal.TryParse(GetElement<TextBox>("ComputeB").Text, out decimal argb))
            {
                return SuccessTask;
            }

            GetElement<TextBlock>("ComputeResult", (ele) => {
                ele.Text = (arga + argb).ToString();
            });

            return SuccessTask;
        } 
    }
}
