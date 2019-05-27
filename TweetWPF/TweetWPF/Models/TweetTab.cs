using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Eleve;

namespace TweetWPF.Models
{
    public class TweetTab : NotificationObject
    {
        /// <summary>
        /// tab header
        /// </summary>
        private string _Header;
        public string Header
        {
            get { return _Header; }
            set { SetProperty(ref _Header, value); }
        }
        /// <summary>
        /// unique key
        /// </summary>
        private string _Key;
        public string Key
        {
            get { return _Key; }
            set { SetProperty(ref _Key, value); }
        }
    }
}
