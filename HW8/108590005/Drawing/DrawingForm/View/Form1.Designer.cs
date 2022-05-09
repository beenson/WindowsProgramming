
namespace DrawingForm
{
    partial class DrawingForm
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
            this._functionTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this._ellipseButton = new System.Windows.Forms.Button();
            this._rectangleButton = new System.Windows.Forms.Button();
            this._clearButton = new System.Windows.Forms.Button();
            this._lineButton = new System.Windows.Forms.Button();
            this._save = new System.Windows.Forms.Button();
            this._load = new System.Windows.Forms.Button();
            this._shapeInformationLabel = new System.Windows.Forms.Label();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._functionTableLayout.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _functionTableLayout
            // 
            this._functionTableLayout.ColumnCount = 6;
            this._functionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._functionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._functionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._functionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._functionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._functionTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this._functionTableLayout.Controls.Add(this._ellipseButton, 1, 0);
            this._functionTableLayout.Controls.Add(this._rectangleButton, 0, 0);
            this._functionTableLayout.Controls.Add(this._clearButton, 3, 0);
            this._functionTableLayout.Controls.Add(this._lineButton, 2, 0);
            this._functionTableLayout.Controls.Add(this._save, 4, 0);
            this._functionTableLayout.Controls.Add(this._load, 5, 0);
            this._functionTableLayout.Dock = System.Windows.Forms.DockStyle.Top;
            this._functionTableLayout.Location = new System.Drawing.Point(0, 27);
            this._functionTableLayout.Name = "_functionTableLayout";
            this._functionTableLayout.RowCount = 1;
            this._functionTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this._functionTableLayout.Size = new System.Drawing.Size(1692, 47);
            this._functionTableLayout.TabIndex = 0;
            // 
            // _ellipseButton
            // 
            this._ellipseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._ellipseButton.Location = new System.Drawing.Point(368, 3);
            this._ellipseButton.Name = "_ellipseButton";
            this._ellipseButton.Size = new System.Drawing.Size(107, 41);
            this._ellipseButton.TabIndex = 1;
            this._ellipseButton.TabStop = false;
            this._ellipseButton.Tag = "";
            this._ellipseButton.Text = "Ellipse";
            this._ellipseButton.UseVisualStyleBackColor = true;
            this._ellipseButton.Click += new System.EventHandler(this.HandleEllipseButtonClick);
            // 
            // _rectangleButton
            // 
            this._rectangleButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._rectangleButton.Location = new System.Drawing.Point(87, 3);
            this._rectangleButton.Name = "_rectangleButton";
            this._rectangleButton.Size = new System.Drawing.Size(107, 41);
            this._rectangleButton.TabIndex = 1;
            this._rectangleButton.TabStop = false;
            this._rectangleButton.Tag = "";
            this._rectangleButton.Text = "Rectangle";
            this._rectangleButton.UseVisualStyleBackColor = true;
            this._rectangleButton.Click += new System.EventHandler(this.HandleRectangleButtonClick);
            // 
            // _clearButton
            // 
            this._clearButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._clearButton.Location = new System.Drawing.Point(930, 3);
            this._clearButton.Name = "_clearButton";
            this._clearButton.Size = new System.Drawing.Size(107, 41);
            this._clearButton.TabIndex = 1;
            this._clearButton.Text = "Clear";
            this._clearButton.UseVisualStyleBackColor = true;
            this._clearButton.Click += new System.EventHandler(this.HandleClearButtonClick);
            // 
            // _lineButton
            // 
            this._lineButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._lineButton.Location = new System.Drawing.Point(649, 3);
            this._lineButton.Name = "_lineButton";
            this._lineButton.Size = new System.Drawing.Size(107, 41);
            this._lineButton.TabIndex = 1;
            this._lineButton.Text = "Line";
            this._lineButton.UseVisualStyleBackColor = true;
            this._lineButton.Click += new System.EventHandler(this.HandleLineButtonClick);
            // 
            // _save
            // 
            this._save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._save.Location = new System.Drawing.Point(1211, 3);
            this._save.Name = "_save";
            this._save.Size = new System.Drawing.Size(107, 41);
            this._save.TabIndex = 1;
            this._save.Text = "Save";
            this._save.UseVisualStyleBackColor = true;
            this._save.Click += new System.EventHandler(this.HandleSaveButtonClick);
            // 
            // _load
            // 
            this._load.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this._load.Location = new System.Drawing.Point(1495, 3);
            this._load.Name = "_load";
            this._load.Size = new System.Drawing.Size(107, 41);
            this._load.TabIndex = 1;
            this._load.Text = "Load";
            this._load.UseVisualStyleBackColor = true;
            this._load.Click += new System.EventHandler(this.HandleLoadButtonClick);
            // 
            // _shapeInformationLabel
            // 
            this._shapeInformationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._shapeInformationLabel.BackColor = System.Drawing.Color.Transparent;
            this._shapeInformationLabel.Location = new System.Drawing.Point(1358, 907);
            this._shapeInformationLabel.Name = "_shapeInformationLabel";
            this._shapeInformationLabel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this._shapeInformationLabel.Size = new System.Drawing.Size(322, 37);
            this._shapeInformationLabel.TabIndex = 1;
            this._shapeInformationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // _menuStrip
            // 
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._undoToolStripMenuItem,
            this._redoToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(1692, 27);
            this._menuStrip.TabIndex = 2;
            this._menuStrip.Text = "menuStrip1";
            // 
            // _undoToolStripMenuItem
            // 
            this._undoToolStripMenuItem.Name = "_undoToolStripMenuItem";
            this._undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this._undoToolStripMenuItem.Size = new System.Drawing.Size(62, 23);
            this._undoToolStripMenuItem.Text = "Undo";
            this._undoToolStripMenuItem.Click += new System.EventHandler(this.ClickUndo);
            // 
            // _redoToolStripMenuItem
            // 
            this._redoToolStripMenuItem.Name = "_redoToolStripMenuItem";
            this._redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Y)));
            this._redoToolStripMenuItem.Size = new System.Drawing.Size(60, 23);
            this._redoToolStripMenuItem.Text = "Redo";
            this._redoToolStripMenuItem.Click += new System.EventHandler(this.ClickRedo);
            // 
            // DrawingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1692, 953);
            this.Controls.Add(this._shapeInformationLabel);
            this.Controls.Add(this._functionTableLayout);
            this.Controls.Add(this._menuStrip);
            this.MainMenuStrip = this._menuStrip;
            this.Name = "DrawingForm";
            this.Text = "Drawing Form";
            this._functionTableLayout.ResumeLayout(false);
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _functionTableLayout;
        private System.Windows.Forms.Button _clearButton;
        private System.Windows.Forms.Button _ellipseButton;
        private System.Windows.Forms.Button _rectangleButton;
        private System.Windows.Forms.Button _lineButton;
        private System.Windows.Forms.Label _shapeInformationLabel;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _redoToolStripMenuItem;
        private System.Windows.Forms.Button _save;
        private System.Windows.Forms.Button _load;
    }
}

