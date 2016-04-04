using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KoLappen.ViewModels
{
    public class QueueListVM
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public bool NeedHelp { get; set; }
        public DateTime HelpTime { get; set; }
        public int QueueNr { get; set; }
        public string UserName { get; set; }
        public bool IsUserItem { get; set; }
        public int TimeWaitedInMin { get; set; }
    }
}
