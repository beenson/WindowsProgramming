
namespace homework1
{
    partial class CourseSelectionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._dataGridViewSelectionCourse = new System.Windows.Forms.DataGridView();
            this._withdraw = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewSelectionCourse)).BeginInit();
            this.SuspendLayout();
            // 
            // _dataGridViewSelectionCourse
            // 
            this._dataGridViewSelectionCourse.AllowUserToAddRows = false;
            this._dataGridViewSelectionCourse.AllowUserToDeleteRows = false;
            this._dataGridViewSelectionCourse.AllowUserToResizeRows = false;
            this._dataGridViewSelectionCourse.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this._dataGridViewSelectionCourse.BackgroundColor = System.Drawing.Color.White;
            this._dataGridViewSelectionCourse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this._dataGridViewSelectionCourse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this._withdraw});
            this._dataGridViewSelectionCourse.Dock = System.Windows.Forms.DockStyle.Fill;
            this._dataGridViewSelectionCourse.Location = new System.Drawing.Point(0, 0);
            this._dataGridViewSelectionCourse.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._dataGridViewSelectionCourse.Name = "_dataGridViewSelectionCourse";
            this._dataGridViewSelectionCourse.ReadOnly = true;
            this._dataGridViewSelectionCourse.RowHeadersVisible = false;
            this._dataGridViewSelectionCourse.RowHeadersWidth = 51;
            this._dataGridViewSelectionCourse.RowTemplate.Height = 27;
            this._dataGridViewSelectionCourse.Size = new System.Drawing.Size(1290, 422);
            this._dataGridViewSelectionCourse.TabIndex = 4;
            this._dataGridViewSelectionCourse.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDataGridViewContent);
            // 
            // _withdraw
            // 
            this._withdraw.HeaderText = "選";
            this._withdraw.MinimumWidth = 6;
            this._withdraw.Name = "_withdraw";
            this._withdraw.ReadOnly = true;
            this._withdraw.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this._withdraw.Text = "退選";
            // 
            // CourseSelectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 422);
            this.Controls.Add(this._dataGridViewSelectionCourse);
            this.Name = "CourseSelectionForm";
            this.Text = "CourseSelectionForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ClosedForm);
            ((System.ComponentModel.ISupportInitialize)(this._dataGridViewSelectionCourse)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView _dataGridViewSelectionCourse;
        private System.Windows.Forms.DataGridViewButtonColumn _withdraw;
    }
}