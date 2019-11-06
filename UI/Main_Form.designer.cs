namespace UI
{
    partial class UserI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserI));
            this.CrimsonPanel = new System.Windows.Forms.Panel();
            this.VideosButton = new System.Windows.Forms.Button();
            this.HomeButton = new System.Windows.Forms.Button();
            this.Youtube_downloaderLabel = new System.Windows.Forms.Label();
            this.SettingsPanel = new System.Windows.Forms.Panel();
            this.SettingsPicture = new System.Windows.Forms.PictureBox();
            this.FormatsPanel = new System.Windows.Forms.Panel();
            this.EndNumeric = new System.Windows.Forms.NumericUpDown();
            this.Playlist_label = new System.Windows.Forms.Label();
            this.EndIndexLabel = new System.Windows.Forms.Label();
            this.StartIndexLabel = new System.Windows.Forms.Label();
            this.StartNumeric = new System.Windows.Forms.NumericUpDown();
            this.URLTextBox = new System.Windows.Forms.TextBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.Videos_control = new UI.Videos_UserControl();
            this.CrimsonPanel.SuspendLayout();
            this.SettingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).BeginInit();
            this.FormatsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // CrimsonPanel
            // 
            this.CrimsonPanel.BackColor = System.Drawing.Color.Crimson;
            this.CrimsonPanel.Controls.Add(this.VideosButton);
            this.CrimsonPanel.Controls.Add(this.HomeButton);
            this.CrimsonPanel.Controls.Add(this.Youtube_downloaderLabel);
            this.CrimsonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.CrimsonPanel.Location = new System.Drawing.Point(0, 0);
            this.CrimsonPanel.Name = "CrimsonPanel";
            this.CrimsonPanel.Size = new System.Drawing.Size(957, 75);
            this.CrimsonPanel.TabIndex = 0;
            // 
            // VideosButton
            // 
            this.VideosButton.FlatAppearance.BorderSize = 0;
            this.VideosButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.VideosButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.VideosButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VideosButton.Image = global::UI.Properties.Resources.Videos_Button;
            this.VideosButton.Location = new System.Drawing.Point(761, 18);
            this.VideosButton.Name = "VideosButton";
            this.VideosButton.Size = new System.Drawing.Size(119, 39);
            this.VideosButton.TabIndex = 4;
            this.VideosButton.Text = "Videos";
            this.VideosButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.VideosButton.UseVisualStyleBackColor = true;
            this.VideosButton.Click += new System.EventHandler(this.VideosButton_Click);
            // 
            // HomeButton
            // 
            this.HomeButton.FlatAppearance.BorderSize = 0;
            this.HomeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.HomeButton.Image = global::UI.Properties.Resources.Home_Button;
            this.HomeButton.Location = new System.Drawing.Point(886, 9);
            this.HomeButton.Name = "HomeButton";
            this.HomeButton.Size = new System.Drawing.Size(59, 51);
            this.HomeButton.TabIndex = 3;
            this.HomeButton.UseVisualStyleBackColor = true;
            this.HomeButton.Click += new System.EventHandler(this.HomeButton_Click);
            // 
            // Youtube_downloaderLabel
            // 
            this.Youtube_downloaderLabel.AutoSize = true;
            this.Youtube_downloaderLabel.Font = new System.Drawing.Font("Century Gothic", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Youtube_downloaderLabel.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Youtube_downloaderLabel.Location = new System.Drawing.Point(197, 18);
            this.Youtube_downloaderLabel.Name = "Youtube_downloaderLabel";
            this.Youtube_downloaderLabel.Size = new System.Drawing.Size(268, 30);
            this.Youtube_downloaderLabel.TabIndex = 0;
            this.Youtube_downloaderLabel.Text = "Youtube Downloader";
            // 
            // SettingsPanel
            // 
            this.SettingsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.SettingsPanel.Controls.Add(this.SettingsPicture);
            this.SettingsPanel.Enabled = false;
            this.SettingsPanel.Location = new System.Drawing.Point(0, 0);
            this.SettingsPanel.Name = "SettingsPanel";
            this.SettingsPanel.Size = new System.Drawing.Size(181, 75);
            this.SettingsPanel.TabIndex = 2;
            // 
            // SettingsPicture
            // 
            this.SettingsPicture.Image = global::UI.Properties.Resources.Settings_Button;
            this.SettingsPicture.Location = new System.Drawing.Point(65, 10);
            this.SettingsPicture.Name = "SettingsPicture";
            this.SettingsPicture.Size = new System.Drawing.Size(50, 50);
            this.SettingsPicture.TabIndex = 0;
            this.SettingsPicture.TabStop = false;
            // 
            // FormatsPanel
            // 
            this.FormatsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.FormatsPanel.Controls.Add(this.EndNumeric);
            this.FormatsPanel.Controls.Add(this.Playlist_label);
            this.FormatsPanel.Controls.Add(this.EndIndexLabel);
            this.FormatsPanel.Controls.Add(this.StartIndexLabel);
            this.FormatsPanel.Controls.Add(this.StartNumeric);
            this.FormatsPanel.Location = new System.Drawing.Point(0, 73);
            this.FormatsPanel.Margin = new System.Windows.Forms.Padding(0);
            this.FormatsPanel.Name = "FormatsPanel";
            this.FormatsPanel.Size = new System.Drawing.Size(181, 429);
            this.FormatsPanel.TabIndex = 5;
            // 
            // EndNumeric
            // 
            this.EndNumeric.AutoSize = true;
            this.EndNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.EndNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EndNumeric.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EndNumeric.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EndNumeric.Location = new System.Drawing.Point(29, 157);
            this.EndNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.EndNumeric.Name = "EndNumeric";
            this.EndNumeric.Size = new System.Drawing.Size(81, 27);
            this.EndNumeric.TabIndex = 13;
            this.EndNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Playlist_label
            // 
            this.Playlist_label.AutoSize = true;
            this.Playlist_label.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Playlist_label.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Playlist_label.Location = new System.Drawing.Point(12, 14);
            this.Playlist_label.Name = "Playlist_label";
            this.Playlist_label.Size = new System.Drawing.Size(73, 22);
            this.Playlist_label.TabIndex = 12;
            this.Playlist_label.Text = "Playlist:";
            this.Playlist_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EndIndexLabel
            // 
            this.EndIndexLabel.AutoSize = true;
            this.EndIndexLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.EndIndexLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.EndIndexLabel.Location = new System.Drawing.Point(25, 123);
            this.EndIndexLabel.Name = "EndIndexLabel";
            this.EndIndexLabel.Size = new System.Drawing.Size(101, 22);
            this.EndIndexLabel.TabIndex = 11;
            this.EndIndexLabel.Text = "End Index";
            this.EndIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartIndexLabel
            // 
            this.StartIndexLabel.AutoSize = true;
            this.StartIndexLabel.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.StartIndexLabel.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartIndexLabel.Location = new System.Drawing.Point(25, 49);
            this.StartIndexLabel.Name = "StartIndexLabel";
            this.StartIndexLabel.Size = new System.Drawing.Size(108, 22);
            this.StartIndexLabel.TabIndex = 10;
            this.StartIndexLabel.Text = "Start Index";
            this.StartIndexLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // StartNumeric
            // 
            this.StartNumeric.AutoSize = true;
            this.StartNumeric.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.StartNumeric.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.StartNumeric.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.StartNumeric.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.StartNumeric.Location = new System.Drawing.Point(28, 84);
            this.StartNumeric.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.StartNumeric.Name = "StartNumeric";
            this.StartNumeric.Size = new System.Drawing.Size(81, 27);
            this.StartNumeric.TabIndex = 2;
            this.StartNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // URLTextBox
            // 
            this.URLTextBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.URLTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.URLTextBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.URLTextBox.Location = new System.Drawing.Point(257, 377);
            this.URLTextBox.Name = "URLTextBox";
            this.URLTextBox.Size = new System.Drawing.Size(623, 24);
            this.URLTextBox.TabIndex = 6;
            this.URLTextBox.Text = "Insert your youtube url here...";
            this.URLTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.URLTextBox.Enter += new System.EventHandler(this.URLTextBox_Enter);
            this.URLTextBox.Leave += new System.EventHandler(this.URLTextBox_Leave);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.Description = "Choose a path where to download the files.";
            // 
            // DownloadButton
            // 
            this.DownloadButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.DownloadButton.FlatAppearance.BorderSize = 0;
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.ForeColor = System.Drawing.Color.AliceBlue;
            this.DownloadButton.Image = global::UI.Properties.Resources.Download_Button;
            this.DownloadButton.Location = new System.Drawing.Point(530, 407);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(76, 68);
            this.DownloadButton.TabIndex = 7;
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // Videos_control
            // 
            this.Videos_control.AutoScroll = true;
            this.Videos_control.BackColor = System.Drawing.Color.AliceBlue;
            this.Videos_control.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Videos_control.ForeColor = System.Drawing.Color.AliceBlue;
            this.Videos_control.Location = new System.Drawing.Point(0, 73);
            this.Videos_control.Name = "Videos_control";
            this.Videos_control.Size = new System.Drawing.Size(957, 429);
            this.Videos_control.TabIndex = 8;
            this.Videos_control.Visible = false;
            // 
            // UserI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(957, 502);
            this.Controls.Add(this.FormatsPanel);
            this.Controls.Add(this.SettingsPanel);
            this.Controls.Add(this.DownloadButton);
            this.Controls.Add(this.URLTextBox);
            this.Controls.Add(this.CrimsonPanel);
            this.Controls.Add(this.Videos_control);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UserI";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Youtube Downloader";
            this.CrimsonPanel.ResumeLayout(false);
            this.CrimsonPanel.PerformLayout();
            this.SettingsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SettingsPicture)).EndInit();
            this.FormatsPanel.ResumeLayout(false);
            this.FormatsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EndNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.StartNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel CrimsonPanel;
        private System.Windows.Forms.Label Youtube_downloaderLabel;
        private System.Windows.Forms.Panel SettingsPanel;
        private System.Windows.Forms.Button HomeButton;
        private System.Windows.Forms.Button VideosButton;
        private System.Windows.Forms.PictureBox SettingsPicture;
        private System.Windows.Forms.Panel FormatsPanel;
        private System.Windows.Forms.TextBox URLTextBox;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
        private Videos_UserControl Videos_control;
        private System.Windows.Forms.NumericUpDown StartNumeric;
        private System.Windows.Forms.Label EndIndexLabel;
        private System.Windows.Forms.Label StartIndexLabel;
        private System.Windows.Forms.Label Playlist_label;
        private System.Windows.Forms.NumericUpDown EndNumeric;
    }
}

