using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Progressive.TimeAttackOnline.ViewModels;
using Progressive.TimeAttackOnline.Commons.Views;

namespace Progressive.TimeAttackOnline.Views
{
    public partial class MainTimerControl : UserControl
    {
        public MainTimerViewModel ViewModel { get; private set; }

        public MainTimerControl()
        {
            ViewModel = new MainTimerViewModel()
            {
                AskResume = () =>
                {
                    return DialogResult.Yes == MessageBox.Show(
                        "取り消してもよろしいですか？（直前の記録は削除されます）", "取り消し確認",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                },
            };
            InitializeComponent();
            startStopButton.Enabled = ViewModel.ButtonCommand.CanExecute(null);
            ViewModel.ButtonCommand.CanExecuteChanged +=
                (sender, e) => startStopButton.Enabled = ViewModel.ButtonCommand.CanExecute(null);
            mainTimerViewModelBindingSource.Add(ViewModel);
            var timer = new Timer();
            timer.Tick += (sender, e) =>
            {
                displayLabel.DataBindings["Text"].ReadValue();
            };
            timer.Interval = 16;
            timer.Start();
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (!ViewModel.ButtonCommand.CanExecute(null))
            {
                return;
            }
            ViewModel.ButtonCommand.Execute(null);
        }
    }
}
