namespace EnglishReader
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ファイルToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.開くCtrlOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.終了CtrlQToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.richTextBox = new System.Windows.Forms.RichTextBox();
            this.inputWPM = new System.Windows.Forms.NumericUpDown();
            this.labelWPM = new System.Windows.Forms.Label();
            this.buttonStartStop = new System.Windows.Forms.Button();
            this.labelFont = new System.Windows.Forms.Label();
            this.inputFontSize = new System.Windows.Forms.NumericUpDown();
            this.menuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputWPM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ファイルToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(808, 40);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ファイルToolStripMenuItem
            // 
            this.ファイルToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.開くCtrlOToolStripMenuItem,
            this.終了CtrlQToolStripMenuItem});
            this.ファイルToolStripMenuItem.Name = "ファイルToolStripMenuItem";
            this.ファイルToolStripMenuItem.Size = new System.Drawing.Size(94, 38);
            this.ファイルToolStripMenuItem.Text = "ファイル";
            // 
            // 開くCtrlOToolStripMenuItem
            // 
            this.開くCtrlOToolStripMenuItem.Name = "開くCtrlOToolStripMenuItem";
            this.開くCtrlOToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.開くCtrlOToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.開くCtrlOToolStripMenuItem.Text = "開く";
            this.開くCtrlOToolStripMenuItem.Click += new System.EventHandler(this.開くCtrlOToolStripMenuItem_Click);
            // 
            // 終了CtrlQToolStripMenuItem
            // 
            this.終了CtrlQToolStripMenuItem.Name = "終了CtrlQToolStripMenuItem";
            this.終了CtrlQToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.終了CtrlQToolStripMenuItem.Size = new System.Drawing.Size(269, 38);
            this.終了CtrlQToolStripMenuItem.Text = "終了";
            this.終了CtrlQToolStripMenuItem.Click += new System.EventHandler(this.終了CtrlQToolStripMenuItem_Click);
            // 
            // richTextBox
            // 
            this.richTextBox.AcceptsTab = true;
            this.richTextBox.AccessibleDescription = "テキストファイルをドラッグ&ドロップしてください";
            this.richTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox.Location = new System.Drawing.Point(1, 45);
            this.richTextBox.Name = "richTextBox";
            this.richTextBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.richTextBox.ShortcutsEnabled = false;
            this.richTextBox.Size = new System.Drawing.Size(806, 586);
            this.richTextBox.TabIndex = 1;
            this.richTextBox.Text = "";
            // 
            // inputWPM
            // 
            this.inputWPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputWPM.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.inputWPM.Location = new System.Drawing.Point(111, 637);
            this.inputWPM.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.inputWPM.Minimum = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.inputWPM.Name = "inputWPM";
            this.inputWPM.Size = new System.Drawing.Size(169, 39);
            this.inputWPM.TabIndex = 2;
            this.inputWPM.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            // 
            // labelWPM
            // 
            this.labelWPM.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelWPM.AutoSize = true;
            this.labelWPM.Font = new System.Drawing.Font("MS UI Gothic", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelWPM.Location = new System.Drawing.Point(12, 642);
            this.labelWPM.Name = "labelWPM";
            this.labelWPM.Size = new System.Drawing.Size(81, 29);
            this.labelWPM.TabIndex = 3;
            this.labelWPM.Text = "WPM:";
            this.labelWPM.Click += new System.EventHandler(this.label1_Click);
            // 
            // buttonStartStop
            // 
            this.buttonStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartStop.Font = new System.Drawing.Font("MS UI Gothic", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonStartStop.Location = new System.Drawing.Point(617, 630);
            this.buttonStartStop.Name = "buttonStartStop";
            this.buttonStartStop.Size = new System.Drawing.Size(152, 60);
            this.buttonStartStop.TabIndex = 4;
            this.buttonStartStop.Text = "START";
            this.buttonStartStop.UseVisualStyleBackColor = true;
            this.buttonStartStop.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelFont
            // 
            this.labelFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelFont.AutoSize = true;
            this.labelFont.Font = new System.Drawing.Font("MS UI Gothic", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.labelFont.Location = new System.Drawing.Point(305, 642);
            this.labelFont.Name = "labelFont";
            this.labelFont.Size = new System.Drawing.Size(75, 29);
            this.labelFont.TabIndex = 6;
            this.labelFont.Text = "Font:";
            this.labelFont.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // inputFontSize
            // 
            this.inputFontSize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.inputFontSize.Font = new System.Drawing.Font("MS UI Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.inputFontSize.Location = new System.Drawing.Point(395, 637);
            this.inputFontSize.Minimum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.inputFontSize.Name = "inputFontSize";
            this.inputFontSize.Size = new System.Drawing.Size(169, 39);
            this.inputFontSize.TabIndex = 5;
            this.inputFontSize.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            this.inputFontSize.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(808, 688);
            this.Controls.Add(this.labelFont);
            this.Controls.Add(this.inputFontSize);
            this.Controls.Add(this.buttonStartStop);
            this.Controls.Add(this.labelWPM);
            this.Controls.Add(this.inputWPM);
            this.Controls.Add(this.richTextBox);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "Form1";
            this.Text = "Form1";
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.inputWPM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem ファイルToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 開くCtrlOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 終了CtrlQToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox;
        private System.Windows.Forms.NumericUpDown inputWPM;
        private System.Windows.Forms.Label labelWPM;
        private System.Windows.Forms.Button buttonStartStop;
        private System.Windows.Forms.Label labelFont;
        private System.Windows.Forms.NumericUpDown inputFontSize;
    }
}

