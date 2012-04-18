namespace Progressive.TimeAttackOnline.Views
{
    partial class SelectorControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.Label label1;
            System.Windows.Forms.TextBox titleTextBox;
            System.Windows.Forms.TextBox passPhraseTextBox;
            System.Windows.Forms.CheckBox isHostCheckBox;
            System.Windows.Forms.DateTimePicker startTimePicker;
            System.Windows.Forms.GroupBox hostGroupBox;
            this.openButton = new System.Windows.Forms.Button();
            this.selectorViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            label3 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            titleTextBox = new System.Windows.Forms.TextBox();
            passPhraseTextBox = new System.Windows.Forms.TextBox();
            isHostCheckBox = new System.Windows.Forms.CheckBox();
            startTimePicker = new System.Windows.Forms.DateTimePicker();
            hostGroupBox = new System.Windows.Forms.GroupBox();
            hostGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectorViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(28, 21);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(43, 12);
            label3.TabIndex = 2;
            label3.Text = "大会名:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(11, 6);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(63, 12);
            label5.TabIndex = 4;
            label5.Text = "パスフレーズ:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(40, 48);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 12);
            label1.TabIndex = 7;
            label1.Text = "日付:";
            // 
            // titleTextBox
            // 
            titleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            titleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.selectorViewModelBindingSource, "Title", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            titleTextBox.Location = new System.Drawing.Point(77, 18);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new System.Drawing.Size(251, 19);
            titleTextBox.TabIndex = 0;
            // 
            // passPhraseTextBox
            // 
            passPhraseTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            passPhraseTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.selectorViewModelBindingSource, "PassPhrase", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            passPhraseTextBox.Location = new System.Drawing.Point(80, 3);
            passPhraseTextBox.Name = "passPhraseTextBox";
            passPhraseTextBox.Size = new System.Drawing.Size(257, 19);
            passPhraseTextBox.TabIndex = 3;
            // 
            // isHostCheckBox
            // 
            isHostCheckBox.AutoSize = true;
            isHostCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.selectorViewModelBindingSource, "IsHost", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            isHostCheckBox.Location = new System.Drawing.Point(11, 27);
            isHostCheckBox.Name = "isHostCheckBox";
            isHostCheckBox.Size = new System.Drawing.Size(48, 16);
            isHostCheckBox.TabIndex = 5;
            isHostCheckBox.Text = "主催";
            isHostCheckBox.UseVisualStyleBackColor = true;
            // 
            // startTimePicker
            // 
            startTimePicker.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            startTimePicker.CustomFormat = "yyyy年MM月dd日 HH時mm分";
            startTimePicker.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.selectorViewModelBindingSource, "StartTime", true));
            startTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            startTimePicker.Location = new System.Drawing.Point(77, 43);
            startTimePicker.Name = "startTimePicker";
            startTimePicker.Size = new System.Drawing.Size(251, 19);
            startTimePicker.TabIndex = 6;
            // 
            // hostGroupBox
            // 
            hostGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            hostGroupBox.Controls.Add(label1);
            hostGroupBox.Controls.Add(label3);
            hostGroupBox.Controls.Add(startTimePicker);
            hostGroupBox.Controls.Add(titleTextBox);
            hostGroupBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.selectorViewModelBindingSource, "IsHost", true));
            hostGroupBox.Enabled = false;
            hostGroupBox.Location = new System.Drawing.Point(3, 28);
            hostGroupBox.Name = "hostGroupBox";
            hostGroupBox.Size = new System.Drawing.Size(334, 74);
            hostGroupBox.TabIndex = 7;
            hostGroupBox.TabStop = false;
            // 
            // openButton
            // 
            this.openButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.openButton.Location = new System.Drawing.Point(262, 108);
            this.openButton.Name = "openButton";
            this.openButton.Size = new System.Drawing.Size(75, 23);
            this.openButton.TabIndex = 8;
            this.openButton.Text = "開く";
            this.openButton.UseVisualStyleBackColor = true;
            this.openButton.Click += new System.EventHandler(this.openButton_Click);
            // 
            // selectorViewModelBindingSource
            // 
            this.selectorViewModelBindingSource.DataSource = typeof(Progressive.TimeAttackOnline.ViewModels.SelectorViewModel);
            // 
            // SelectorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.openButton);
            this.Controls.Add(isHostCheckBox);
            this.Controls.Add(hostGroupBox);
            this.Controls.Add(passPhraseTextBox);
            this.Controls.Add(label5);
            this.Name = "SelectorControl";
            this.Size = new System.Drawing.Size(340, 136);
            hostGroupBox.ResumeLayout(false);
            hostGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectorViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource selectorViewModelBindingSource;
        private System.Windows.Forms.Button openButton;
    }
}
