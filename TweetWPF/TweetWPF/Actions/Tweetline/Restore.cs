using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace TweetWPF.Actions.Tweetline
{
    public class Restore : TweetlineActionBase
    {
        public override Task<ActionResult> Execute(object sender, EventArgs args, object obj)
        {
            return OK;
        }
    }
}
