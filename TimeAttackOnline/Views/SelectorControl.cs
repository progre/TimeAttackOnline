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
    public partial class SelectorControl : UserControl
    {
        private SelectorViewModel viewModel = new SelectorViewModel();

        public event Action OnSelected;

        public SelectorControl()
        {
            InitializeComponent();
            selectorViewModelBindingSource.Add(viewModel);
            viewModel.OpenCommand.CanExecuteChanged +=
                (sender, e) => openButton.Enabled = viewModel.OpenCommand.CanExecute(null);
            openButton.Enabled = viewModel.OpenCommand.CanExecute(null);
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (!viewModel.OpenCommand.CanExecute(null))
            {
                openButton.Enabled = false;
                return;
            }
            viewModel.OpenCommand.Execute(null);
            foreach (Control ctrl in Controls)
            {
                ctrl.Enabled = false;
            }
            UseWaitCursor = true;
        }
    }
}
