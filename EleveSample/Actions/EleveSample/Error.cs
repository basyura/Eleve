﻿using System;
using System.Threading.Tasks;
using Eleve;

namespace EleveSample.Actions.EleveSample
{
    public class Error : EleveSampleActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs e, object obj)
        {
            throw new Exception("Sample Error");
        }
    }
}
