namespace TimeAttackOnline.Views
{
    partial class MainForm
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

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.mainTimerControl = new Progressive.TimeAttackOnline.Views.MainTimerControl();
            this.selectorControl = new Progressive.TimeAttackOnline.Views.SelectorControl();
            this.SuspendLayout();
            // 
            // mainTimerControl
            // 
            this.mainTimerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTimerControl.Location = new System.Drawing.Point(0, 0);
            this.mainTimerControl.Name = "mainTimerControl";
            this.mainTimerControl.Size = new System.Drawing.Size(374, 135);
            this.mainTimerControl.TabIndex = 1;
            // 
            // selectorControl
            // 
            this.selectorControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.selectorControl.Location = new System.Drawing.Point(0, 0);
            this.selectorControl.Name = "selectorControl";
            this.selectorControl.Size = new System.Drawing.Size(374, 135);
            this.selectorControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 135);
            this.Controls.Add(this.mainTimerControl);
            this.Controls.Add(this.selectorControl);
            this.Name = "MainForm";
            this.Text = "TimeAttackOnline";
            this.ResumeLayout(false);

        }

        #endregion

        private Progressive.TimeAttackOnline.Views.SelectorControl selectorControl;
        private Progressive.TimeAttackOnline.Views.MainTimerControl mainTimerControl;



    }
}

