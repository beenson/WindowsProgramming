
namespace homework1
{
    partial class ImportCourseProgressForm
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
            this._progressBar = new System.Windows.Forms.ProgressBar();
            this._importCourseProgressLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // _progressBar
            // 
            this._progressBar.Location = new System.Drawing.Point(4, 89);
            this._progressBar.Name = "_progressBar";
            this._progressBar.Size = new System.Drawing.Size(800, 87);
            this._progressBar.TabIndex = 0;
            // 
            // _importCourseProgressLable
            // 
            this._importCourseProgressLable.AutoSize = true;
            this._importCourseProgressLable.Font = new System.Drawing.Font("新細明體", 12F);
            this._importCourseProgressLable.Location = new System.Drawing.Point(12, 61);
            this._importCourseProgressLable.Name = "_importCourseProgressLable";
            this._importCourseProgressLable.Size = new System.Drawing.Size(169, 20);
            this._importCourseProgressLable.TabIndex = 1;
            this._importCourseProgressLable.Text = "正在匯入課程...0%";
            // 
            // ImportCourseProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 255);
            this.Controls.Add(this._importCourseProgressLable);
            this.Controls.Add(this._progressBar);
            this.Name = "ImportCourseProgressForm";
            this.Text = "匯入課程";
            this.Shown += new System.EventHandler(this.ShownForm);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar _progressBar;
        private System.Windows.Forms.Label _importCourseProgressLable;
    }
}