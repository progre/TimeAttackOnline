using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Progressive.TimeAttackOnline.Commons.ViewModels
{
    public static class ViewModelUtils
    {
        public static PropertyChangedEventHandler
            ToPropertyChangedEventHandler(string propertyName, Action action)
        {
            return (sender, e) =>
            {
                if (e.PropertyName != propertyName)
                {
                    return;
                }
                action();
            };
        }
    }
}
