using System.ComponentModel;
using System.Diagnostics;

namespace Progressive.TimeAttackOnline.Commons.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged メンバー

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        protected void NotifyPropertyChanged(string propertyName)
        {
            Debug.Assert(GetType().GetProperty(propertyName) != null);

            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
