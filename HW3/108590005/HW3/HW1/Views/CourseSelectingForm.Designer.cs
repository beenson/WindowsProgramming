
namespace homework1
{
    partial class CourseSelectingForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this._buttonCheckResult = new System.Windows.Forms.Button();
            this._buttonConfirm = new System.Windows.Forms.Button();
            this._tabControl = new System.Windows.Forms.TabControl();
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // _buttonCheckResult
            // 
            this._buttonCheckResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonCheckResult.Location = new System.Drawing.Point(1469, 688);
            this._buttonCheckResult.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._buttonCheckResult.Name = "_buttonCheckResult";
            this._buttonCheckResult.Size = new System.Drawing.Size(209, 82);
            this._buttonCheckResult.TabIndex = 1;
            this._buttonCheckResult.Text = "查看選課結果";
            this._buttonCheckResult.UseVisualStyleBackColor = true;
            this._buttonCheckResult.Click += new System.EventHandler(this.ClickCheckResultButton);
            // 
            // _buttonConfirm
            // 
            this._buttonConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonConfirm.Enabled = false;
            this._buttonConfirm.Location = new System.Drawing.Point(1239, 688);
            this._buttonConfirm.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._buttonConfirm.Name = "_buttonConfirm";
            this._buttonConfirm.Size = new System.Drawing.Size(209, 82);
            this._buttonConfirm.TabIndex = 1;
            this._buttonConfirm.Text = "確認送出";
            this._buttonConfirm.UseVisualStyleBackColor = true;
            this._buttonConfirm.Click += new System.EventHandler(this.ClickButtonConfirm);
            // 
            // _tabControl
            // 
            this._tableLayoutPanel.SetColumnSpan(this._tabControl, 2);
            this._tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tabControl.Location = new System.Drawing.Point(4, 4);
            this._tabControl.Margin = new System.Windows.Forms.Padding(4);
            this._tabControl.Name = "_tabControl";
            this._tabControl.SelectedIndex = 0;
            this._tabControl.Size = new System.Drawing.Size(1673, 674);
            this._tabControl.TabIndex = 2;
            this._tabControl.Tag = "2423";
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnCount = 2;
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 230F));
            this._tableLayoutPanel.Controls.Add(this._tabControl, 0, 0);
            this._tableLayoutPanel.Controls.Add(this._buttonCheckResult, 1, 1);
            this._tableLayoutPanel.Controls.Add(this._buttonConfirm, 0, 1);
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.RowCount = 2;
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this._tableLayoutPanel.Size = new System.Drawing.Size(1681, 772);
            this._tableLayoutPanel.TabIndex = 3;
            // 
            // CourseSelectingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1681, 772);
            this.Controls.Add(this._tableLayoutPanel);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "CourseSelectingForm";
            this.Text = "選課";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClosedForm);
            this._tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _buttonCheckResult;
        private System.Windows.Forms.Button _buttonConfirm;
        private System.Windows.Forms.TabControl _tabControl;
        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
    }
}

