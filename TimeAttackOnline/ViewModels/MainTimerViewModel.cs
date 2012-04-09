using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Progressive.TimeAttackOnline.ViewModels
{
    public class MainTimerViewModel
    {
        public Mode Mode { get; private set; }
        public string Title { get; private set; }
        public string Count { get; private set; }
        public string PassPhrase { get; private set; }
    }

    public enum Mode
    {
        Waiting, Running, Finished
    }
}
