using System;
using System.Windows.Controls;

namespace EleveSample.Actions.EleveSample
{
    public class Compute : EleveSampleActionBase
    {
        /// <summary>
        /// MVVM でもできるんだけど，恐れずに View にアクセスするサンプル。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="evnt"></param>
        /// <param name="parameter"></param>
        public override void Execute(object sender, EventArgs evnt, object parameter)
        {
            decimal arga;
            if (!decimal.TryParse(GetElement<TextBox>("ComputeA").Text, out arga))
            {
                return;
            }
            decimal argb;
            if (!decimal.TryParse(GetElement<TextBox>("ComputeB").Text, out argb))
            {
                return;
            }

            GetElement<TextBlock>("ComputeResult", (ele) => {
                ele.Text = (arga + argb).ToString();
            });
        } 
    }
}
