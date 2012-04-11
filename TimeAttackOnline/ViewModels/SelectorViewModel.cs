using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using Progressive.TimeAttackOnline.Commons.ViewModels;
using System.Windows.Input;
using Progressive.TimeAttackOnline.Models;
using System.Threading.Tasks;
using Codeplex.Data;

namespace Progressive.TimeAttackOnline.ViewModels
{
    public class SelectorViewModel : ViewModelBase
    {
        public event Action<bool?, bool> OnProcessed;

        private string passPhrase;
        public string PassPhrase
        {
            get { return passPhrase; }
            set
            {
                if (passPhrase == value)
                {
                    return;
                }
                passPhrase = value;
                NotifyPropertyChanged("PassPhrase");
            }
        }
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
        public DateTime StartTime { get; set; }

        private DelegateCommand openCommand;
        public ICommand OpenCommand { get { return openCommand; } }

        public SelectorViewModel()
        {
            openCommand = new DelegateCommand(
                async parameter =>
                {
                    var model = new ServerModel();
                    if (isHost)
                    {
                        bool? result = await model.AddEventAsync(PassPhrase, Title, StartTime);
                        OnProcessed(result, true);
                    }
                    else
                    {
                        var result = await model.GetEventAsync(PassPhrase);
                        if (result.Item1 == true)
                        {
                            var json = DynamicJson.Parse(result.Item2);
                            Title = json.title;
                            StartTime = json["start-time"];
                        }
                        OnProcessed(result.Item1, false);
                    }
                },
                parameter =>
                {
                    if (string.IsNullOrEmpty(PassPhrase))
                    {
                        return false;
                    }
                    return true;
                });

            PropertyChanged += ViewModelUtils.ToPropertyChangedEventHandler(
                "PassPhrase", openCommand.NotifyCanExecuteChanged);
        }
    }
}
