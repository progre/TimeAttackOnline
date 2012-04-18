using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Progressive.TimeAttackOnline.Commons.ViewModels;
using System.Windows.Input;
using System.Threading;
using Progressive.TimeAttackOnline.Models;
using Codeplex.Data;
using System.IO;
using System.Windows.Forms;

namespace Progressive.TimeAttackOnline.ViewModels
{
    public class MainTimerViewModel : ViewModelBase
    {
        private dynamic settings;
        private bool countStarted;
        private HotKey hotKey;

        public Func<bool> AskResume { private get; set; }

        public string PassPhrase { get; set; }
        public string Title { get; set; }
        private DateTime startTime;
        public DateTime StartTime
        {
            get { return startTime; }
            set
            {
                startTime = value;
                mode = Mode.Running;
            }
        }
        public DateTime StopTime { get; private set; }
        private Mode mode;
        public Mode Mode
        {
            get { return mode; }
            private set
            {
                if (mode == value)
                {
                    return;
                }
                mode = value;
                NotifyPropertyChanged("ButtonLabel");
            }
        }
        private DelegateCommand buttonCommand;
        public ICommand ButtonCommand { get { return buttonCommand; } }
        public string ButtonLabel
        {
            get
            {
                return mode == Mode.Running ? "Stop" :
                    mode == Mode.Finished ? "Resume" : "";
            }
        }
        public TimeSpan Count
        {
            get
            {
                switch (mode)
                {
                    case Mode.Running:
                        return DateTime.Now - StartTime;
                    case Mode.Finished:
                        return StopTime - StartTime;
                    case Mode.Undefined:
                        return TimeSpan.FromTicks(0);
                    default:
                        throw new ApplicationException();
                }
            }
        }
        public string CountString
        {
            get
            {
                var ts = Count;
                if (countStarted || ts.Ticks >= 0)
                {
                    if (!countStarted)
                    {
                        countStarted = true;
                        buttonCommand.NotifyCanExecuteChanged();
                    }
                    return new StringBuilder().Append(ts.TotalHours.ToString("00")).Append(':')
                        .Append(ts.Minutes.ToString("00")).Append('\'')
                        .Append(ts.Seconds.ToString("00")).Append("''")
                        .Append(ts.Milliseconds.ToString("000")).ToString();
                }
                else
                {
                    ts = ts + TimeSpan.FromSeconds(-1);
                    return new StringBuilder().Append((-ts.TotalHours).ToString("00")).Append(':')
                        .Append((-ts.Minutes).ToString("00")).Append('\'')
                        .Append((-ts.Seconds).ToString("00")).Append("''")
                        .Append("000").ToString();

                }
            }
        }

        public MainTimerViewModel()
        {
            try
            {
                string jsonString = File.ReadAllText("settings.json");
                settings = DynamicJson.Parse(jsonString);
                Keys key = (Keys)new KeysConverter().ConvertFromString(((string)settings.hotkey).ToUpper());
                hotKey = new HotKey(ModifyKey.Undefined, key);
                hotKey.Pushed += (sender, e) => { buttonCommand.Execute(null); };
            }
            catch (Exception e)
            {
                e.ToString();
            }

            Mode = Mode.Undefined;
            buttonCommand = new DelegateCommand(
                parameter =>
                {
                    switch (mode)
                    {
                        case Mode.Running:
                            StopTime = DateTime.Now;
                            Mode = Mode.Finished;
                            return;
                        case Mode.Finished:
                            if (!AskResume())
                            {
                                return;
                            }
                            Mode = Mode.Running;
                            return;
                        case Mode.Undefined:
                            return;
                        default:
                            throw new ApplicationException();
                    }
                },
                parameter =>
                {
                    switch (mode)
                    {
                        case Mode.Running:
                            return Count.Ticks >= 0;
                        case Mode.Finished:
                            return true;
                        case Mode.Undefined:
                            return false;
                        default:
                            throw new ApplicationException();
                    }
                });
        }
    }

    public enum Mode
    {
        Undefined = 0,
        Running, Finished
    }
}
