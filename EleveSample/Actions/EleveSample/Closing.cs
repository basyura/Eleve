﻿using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Closing : EleveSampleActionBase
    {
        public override async Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            if (ViewModel.IsTerminating)
            {
                return Success;
            }
            CancelEventArgs evnt = e as CancelEventArgs;
            evnt.Cancel = true;

            bool result = await Task.Run(() =>
            {
                Thread.Sleep(1000);
                return true;
            });

            if (result)
            {
                ViewModel.IsTerminating = true;
                App.Current.Shutdown();
            }

            return Success;
        }
    }
}