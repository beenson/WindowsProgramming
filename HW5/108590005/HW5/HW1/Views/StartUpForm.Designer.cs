
namespace homework1
{
    partial class StartUpForm
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
            this._courseSelectingSystemButton = new System.Windows.Forms.Button();
            this._exitButton = new System.Windows.Forms.Button();
            this._courseManagementSystemButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _courseSelectingSystemButton
            // 
            this._courseSelectingSystemButton.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this._courseSelectingSystemButton.Location = new System.Drawing.Point(12, 12);
            this._courseSelectingSystemButton.Name = "_courseSelectingSystemButton";
            this._courseSelectingSystemButton.Size = new System.Drawing.Size(1225, 241);
            this._courseSelectingSystemButton.TabIndex = 0;
            this._courseSelectingSystemButton.Text = "Course Selecting System";
            this._courseSelectingSystemButton.UseVisualStyleBackColor = true;
            this._courseSelectingSystemButton.Click += new System.EventHandler(this.ClickCourseSelectingSystemButton);
            // 
            // _exitButton
            // 
            this._exitButton.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold);
            this._exitButton.Location = new System.Drawing.Point(926, 506);
            this._exitButton.Name = "_exitButton";
            this._exitButton.Size = new System.Drawing.Size(311, 107);
            this._exitButton.TabIndex = 2;
            this._exitButton.Text = "Exit";
            this._exitButton.UseVisualStyleBackColor = true;
            this._exitButton.Click += new System.EventHandler(this.ClickExitButton);
            // 
            // _courseManagementSystemButton
            // 
            this._courseManagementSystemButton.Font = new System.Drawing.Font("Trebuchet MS", 24F, System.Drawing.FontStyle.Bold);
            this._courseManagementSystemButton.Location = new System.Drawing.Point(12, 259);
            this._courseManagementSystemButton.Name = "_courseManagementSystemButton";
            this._courseManagementSystemButton.Size = new System.Drawing.Size(1225, 241);
            this._courseManagementSystemButton.TabIndex = 3;
            this._courseManagementSystemButton.Text = "Course Management System";
            this._courseManagementSystemButton.UseVisualStyleBackColor = true;
            this._courseManagementSystemButton.Click += new System.EventHandler(this.ClickCourseManagementSystemButton);
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 625);
            this.Controls.Add(this._courseManagementSystemButton);
            this.Controls.Add(this._exitButton);
            this.Controls.Add(this._courseSelectingSystemButton);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _courseSelectingSystemButton;
        private System.Windows.Forms.Button _exitButton;
        private System.Windows.Forms.Button _courseManagementSystemButton;
    }
}