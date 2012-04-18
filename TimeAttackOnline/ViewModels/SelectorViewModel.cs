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
using System.Globalization;

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
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (title == value)
                {
                    return;
                }
                title = value;
                NotifyPropertyChanged("Title");
            }
        }
        public DateTime StartTime { get; set; }

        private DelegateCommand openCommand;
        public ICommand OpenCommand { get { return openCommand; } }

        public SelectorViewModel()
        {
            var now = DateTime.Now;
            StartTime = now.AddMilliseconds(-now.Second * 1000 - now.Millisecond);

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
                        if (result.Item1 == false)
                        {
                            OnProcessed(false, false);
                            return;
                        }
                        var json = DynamicJson.Parse(result.Item2);
                        if (json.result != "success")
                        {
                            OnProcessed(false, false);
                            return;
                        }
                        Title = json.title;
                        StartTime = DateTime.Parse(json["start-date"], CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                        OnProcessed(true, false);
                    }
                },
                parameter =>
                {
                    if (string.IsNullOrEmpty(PassPhrase)
                        || IsHost && string.IsNullOrEmpty(Title))
                    {
                        return false;
                    }
                    return true;
                });

            PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName != "PassPhrase"
                    && e.PropertyName != "IsHost"
                    && e.PropertyName != "Title")
                {
                    return;
                }
                openCommand.NotifyCanExecuteChanged();
            };
        }
    }
}
