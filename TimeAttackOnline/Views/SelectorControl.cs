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
        public event Action OnSelected = () => { };
        public SelectorViewModel ViewModel { get; private set; }

        public SelectorControl()
        {
            ViewModel = new SelectorViewModel();
            InitializeComponent();
            selectorViewModelBindingSource.Add(ViewModel);
            ViewModel.OpenCommand.CanExecuteChanged +=
                (sender, e) => openButton.Enabled = ViewModel.OpenCommand.CanExecute(null);
            openButton.Enabled = ViewModel.OpenCommand.CanExecute(null);
            ViewModel.OnProcessed += (result, isHost) =>
            {
                EndProcessing();
                switch (result)
                {
                    case true:
                        OnSelected();
                        return;
                    case false:
                        if (isHost)
                        {
                            MessageBox.Show("作成に失敗しました。指定したパスフレーズは既に使用されています。", "作成に失敗",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("参加に失敗しました。パスフレーズが違います。", "参加に失敗",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    case null:
                        MessageBox.Show("サーバとの接続に失敗しました。暫く時間を置いてから再試行してください。", "サーバとの接続に失敗",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
            };
        }

        private void openButton_Click(object sender, EventArgs e)
        {
            if (!ViewModel.OpenCommand.CanExecute(null))
            {
                openButton.Enabled = false;
                return;
            }
            ViewModel.OpenCommand.Execute(null);
            StartProcessing();
        }

        private void StartProcessing()
        {
            Enabled = false;
            Parent.UseWaitCursor = true;
        }

        private void EndProcessing()
        {
            Enabled = true;
            Parent.UseWaitCursor = false;
        }
    }
}
