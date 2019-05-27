using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TweetWPF.Models;

namespace TweetWPF.Models
{
    public class NavigateParam
    {
        /// <summary></summary>
        public TweetTab Tab { get; set; }

        public NavigateMode Mode { get; set; }
    }
}
