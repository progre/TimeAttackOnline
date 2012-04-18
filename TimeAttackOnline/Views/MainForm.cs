using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Progressive.TimeAttackOnline.ViewModels;

namespace TimeAttackOnline.Views
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            mainTimerControl.Visible = false;
            selectorControl.OnProcessed += () =>
            {
                var mt = mainTimerControl.ViewModel;
                var s = selectorControl.ViewModel;
                mt.PassPhrase = s.PassPhrase;
                mt.Title = s.Title;
                mt.StartTime = s.StartTime;
                selectorControl.Visible = false;
                mainTimerControl.Visible = true;
            };
        }
    }
}
