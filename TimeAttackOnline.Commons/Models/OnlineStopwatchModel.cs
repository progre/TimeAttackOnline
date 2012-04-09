using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Progressive.TimeAttackOnline.Models
{
    internal class OnlineStopwatchModel
    {
        private TimeSpan diffNict;

        internal OnlineStopwatchModel(TimeSpan diffNict)
        {
            this.diffNict = diffNict;
        }

        internal DateTime Difference
        {
            get
            {
                return DateTime.Now.Add(diffNict);
            }
        }
    }
}
