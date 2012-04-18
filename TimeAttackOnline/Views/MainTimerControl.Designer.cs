namespace Progressive.TimeAttackOnline.Views
{
    partial class MainTimerControl
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
            System.Windows.Forms.TextBox textBox1;
            System.Windows.Forms.Label label1;
            this.displayLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.startStopButton = new System.Windows.Forms.Button();
            this.mainTimerViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            textBox1 = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainTimerViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // displayLabel
            // 
            this.displayLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainTimerViewModelBindingSource, "CountString", true));
            this.displayLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.displayLabel.Font = new System.Drawing.Font("MS UI Gothic", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.displayLabel.Location = new System.Drawing.Point(0, 21);
            this.displayLabel.Name = "displayLabel";
            this.displayLabel.Size = new System.Drawing.Size(370, 93);
            this.displayLabel.TabIndex = 7;
            this.displayLabel.Text = "00:00\'00\'\'000";
            this.displayLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(textBox1);
            this.panel1.Controls.Add(this.startStopButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 114);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(370, 23);
            this.panel1.TabIndex = 9;
            // 
            // textBox1
            // 
            textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            textBox1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainTimerViewModelBindingSource, "PassPhrase", true));
            textBox1.Location = new System.Drawing.Point(0, 3);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new System.Drawing.Size(217, 19);
            textBox1.TabIndex = 2;
            textBox1.Text = "rockman2ta";
            // 
            // startStopButton
            // 
            this.startStopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.startStopButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.startStopButton.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainTimerViewModelBindingSource, "ButtonLabel", true));
            this.startStopButton.Location = new System.Drawing.Point(220, 1);
            this.startStopButton.Margin = new System.Windows.Forms.Padding(0);
            this.startStopButton.Name = "startStopButton";
            this.startStopButton.Size = new System.Drawing.Size(150, 22);
            this.startStopButton.TabIndex = 1;
            this.startStopButton.Text = "start / stop";
            this.startStopButton.UseVisualStyleBackColor = true;
            this.startStopButton.UseWaitCursor = true;
            this.startStopButton.Click += new System.EventHandler(this.StartStopButton_Click);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainTimerViewModelBindingSource, "Title", true));
            label1.Dock = System.Windows.Forms.DockStyle.Top;
            label1.Font = new System.Drawing.Font("MS UI Gothic", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            label1.Location = new System.Drawing.Point(0, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(289, 21);
            label1.TabIndex = 8;
            label1.Text = "ロックマン2TA 2012/4/3 23:50～";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // mainTimerViewModelBindingSource
            // 
            this.mainTimerViewModelBindingSource.DataSource = typeof(Progressive.TimeAttackOnline.ViewModels.MainTimerViewModel);
            // 
            // MainTimerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.displayLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(label1);
            this.Name = "MainTimerControl";
            this.Size = new System.Drawing.Size(370, 137);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainTimerViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button startStopButton;
        private System.Windows.Forms.BindingSource mainTimerViewModelBindingSource;
        private System.Windows.Forms.Label displayLabel;
    }
}
