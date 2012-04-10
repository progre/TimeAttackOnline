using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Progressive.TimeAttackOnline.Commons.ViewModels;
using System.Windows.Input;
using Progressive.TimeAttackOnline.Models;

namespace Progressive.TimeAttackOnline.ViewModels
{
    public class SelectorViewModel : ViewModelBase
    {
        public event Action OnSucceeded;
        public event Action OnFailed;

        public string PassPhrase { get; set; }
        private bool isHost;
        public bool IsHost
        {
            get { return isHost; }
            set
            {
                if (isHost == value)
                {
                    return;
                }
                isHost = value;
                NotifyPropertyChanged("IsHost");
            }
        }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }

        public ICommand OpenCommand { get; private set; }

        public SelectorViewModel()
        {
            OpenCommand = new DelegateCommand(
                parameter =>
                {
                    new ServerModel();
                    OnSucceeded();
                },
                parameter => true);
        }
    }
}
