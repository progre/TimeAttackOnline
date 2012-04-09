using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Progressive.TimeAttackOnline.Commons.Views
{
    public static class FormUtils
    {
        public static PropertyChangedEventHandler
            ToPropertyChangedEventHandler(string propertyName, Control invoker, Action action)
        {
            return (sender, e) =>
            {
                if (e.PropertyName != propertyName)
                {
                    return;
                }
                invoker.BeginInvoke(action);
            };
        }

        public static bool? ToNullableBool(DialogResult result)
        {
            switch (result)
            {
                case DialogResult.Yes:
                    return true;
                case DialogResult.No:
                    return false;
                case DialogResult.Cancel:
                default:
                    return null;
            }
        }
    }
}
