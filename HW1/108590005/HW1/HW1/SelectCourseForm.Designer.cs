
namespace homework1
{
    partial class SelectCourseForm
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
            this._dataGridViewCourse = new System.Windows.Forms.DataGridView();
            this._select = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // _buttonCheckResult
            // 
            this._buttonCheckResult.Location = new System.Drawing.Point(1459, 596);
            this._buttonCheckResult.Name = "_buttonCheckResult";
            this._buttonCheckResult.Size = new System.Drawing.Size(209, 83);
            this._buttonCheckResult.TabIndex = 1;
            this._buttonCheckResult.Text = "查看選課結果";
            this._buttonCheckResult.UseVisualStyleBackColor = true;
            // 
            // _buttonConfirm
            // 
            this._buttonConfirm.Enabled = false;
            this._buttonConfirm.Location = new System.Drawing.Point(1244, 596);
            this._buttonConfirm.Name = "_buttonConfirm";
            this._buttonConfirm.Size = new System.Drawing.Size(209, 83);
            this._buttonConfirm.TabIndex = 1;
            this._buttonConfirm.Text = "確認送出";
            this._buttonConfirm.UseVisualStyleBackColor = true;
            // 
            // _dataGridViewCourse
            // 
            this._dataGridViewCourse.AllowUserToAddRows = false;
            this._dataGridViewCourse.AllowUserToDeleteRows = false;
            this._dataGridViewCourse.AllowUserToResizeRows = false;
            this._dataGridViewCourse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridViewCourse.BackgroundColor = System.Drawing.Color.White;
            this._dataGridViewCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewCourse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._select});
            this._dataGridViewCourse.Dock = System.Windows.Forms.DockStyle.Top;
            this._dataGridViewCourse.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewCourse.Name = "_dataGridViewCourse";
            this._dataGridViewCourse.RowHeadersVisible = false;
            this._dataGridViewCourse.RowHeadersWidth = 51;
            this._dataGridViewCourse.RowTemplate.Height = 27;
            this._dataGridViewCourse.Size = new System.Drawing.Size(1680, 590);
            this._dataGridViewCourse.TabIndex = 0;
            this._dataGridViewCourse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ContentClickDataGridViewCourse);
            this._dataGridViewCourse.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.ValueChangedDataGridViewCourse);
            // 
            // _select
            // 
            this._select.HeaderText = "選";
            this._select.MinimumWidth = 6;
            this._select.Name = "_select";
            // 
            // SelectCourseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1680, 691);
            this.Controls.Add(this._dataGridViewCourse);
            this.Controls.Add(this._buttonConfirm);
            this.Controls.Add(this._buttonCheckResult);
            this.Name = "SelectCourseForm";
            this.Text = "SelectCourseForm";
            this.Load += new System.EventHandler(this.LoadSelectCourseForm);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewCourse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button _buttonCheckResult;
        private System.Windows.Forms.Button _buttonConfirm;
        private System.Windows.Forms.DataGridView _dataGridViewCourse;
        private System.Windows.Forms.DataGridViewCheckBoxColumn _select;
    }
}

