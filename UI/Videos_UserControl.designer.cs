namespace UI
{
    partial class Videos_UserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VideoGridView = new System.Windows.Forms.DataGridView();
            this.CheckBox = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Nr = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Download = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.AllBox = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.Change_Button = new System.Windows.Forms.Button();
            this.DownloadButton = new System.Windows.Forms.Button();
            this.Type_box = new System.Windows.Forms.ComboBox();
            this.ClearButton = new System.Windows.Forms.Button();
            this.Quality_Box = new System.Windows.Forms.ComboBox();
            this.TagBox = new System.Windows.Forms.CheckBox();
            this.Format_box = new System.Windows.Forms.ComboBox();
            this.FolderBrowser = new System.Windows.Forms.FolderBrowserDialog();
            ((System.ComponentModel.ISupportInitialize)(this.VideoGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VideoGridView
            // 
            this.VideoGridView.AllowUserToAddRows = false;
            this.VideoGridView.AllowUserToDeleteRows = false;
            this.VideoGridView.AllowUserToResizeColumns = false;
            this.VideoGridView.AllowUserToResizeRows = false;
            this.VideoGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.VideoGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.VideoGridView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.VideoGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
            this.VideoGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 13F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VideoGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.VideoGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.VideoGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CheckBox,
            this.Nr,
            this.ID,
            this.Title,
            this.Download});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.VideoGridView.DefaultCellStyle = dataGridViewCellStyle2;
            this.VideoGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VideoGridView.EnableHeadersVisualStyles = false;
            this.VideoGridView.GridColor = System.Drawing.Color.AliceBlue;
            this.VideoGridView.Location = new System.Drawing.Point(0, 44);
            this.VideoGridView.Name = "VideoGridView";
            this.VideoGridView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle3.NullValue = "1";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.InfoText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.VideoGridView.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.VideoGridView.RowHeadersVisible = false;
            this.VideoGridView.RowHeadersWidth = 60;
            this.VideoGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.InfoText;
            this.VideoGridView.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.VideoGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.VideoGridView.ShowCellErrors = false;
            this.VideoGridView.ShowCellToolTips = false;
            this.VideoGridView.ShowEditingIcon = false;
            this.VideoGridView.ShowRowErrors = false;
            this.VideoGridView.Size = new System.Drawing.Size(957, 385);
            this.VideoGridView.TabIndex = 2;
            this.VideoGridView.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.VideoGridView_CellContentClick);
            this.VideoGridView.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.VideoGridView_CellMouseClick);
            this.VideoGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.VideoGridView_ColumnHeaderMouseClick);
            // 
            // CheckBox
            // 
            this.CheckBox.HeaderText = "";
            this.CheckBox.Name = "CheckBox";
            this.CheckBox.Width = 50;
            // 
            // Nr
            // 
            this.Nr.HeaderText = "Nr";
            this.Nr.Name = "Nr";
            this.Nr.ReadOnly = true;
            this.Nr.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Nr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            this.ID.Width = 200;
            // 
            // Title
            // 
            this.Title.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Title.HeaderText = "Title";
            this.Title.Name = "Title";
            this.Title.ReadOnly = true;
            // 
            // Download
            // 
            this.Download.HeaderText = "Download";
            this.Download.MaxDropDownItems = 50;
            this.Download.Name = "Download";
            this.Download.Width = 250;
            // 
            // AllBox
            // 
            this.AllBox.AutoCheck = false;
            this.AllBox.AutoSize = true;
            this.AllBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.AllBox.FlatAppearance.BorderSize = 0;
            this.AllBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.AllBox.Location = new System.Drawing.Point(19, 52);
            this.AllBox.Name = "AllBox";
            this.AllBox.Size = new System.Drawing.Size(12, 11);
            this.AllBox.TabIndex = 3;
            this.AllBox.UseVisualStyleBackColor = false;
            this.AllBox.Click += new System.EventHandler(this.AllBox_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.panel1.Controls.Add(this.Change_Button);
            this.panel1.Controls.Add(this.DownloadButton);
            this.panel1.Controls.Add(this.Type_box);
            this.panel1.Controls.Add(this.ClearButton);
            this.panel1.Controls.Add(this.Quality_Box);
            this.panel1.Controls.Add(this.TagBox);
            this.panel1.Controls.Add(this.Format_box);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(957, 44);
            this.panel1.TabIndex = 4;
            // 
            // Change_Button
            // 
            this.Change_Button.FlatAppearance.BorderSize = 0;
            this.Change_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Change_Button.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Change_Button.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.Change_Button.Location = new System.Drawing.Point(709, 7);
            this.Change_Button.Name = "Change_Button";
            this.Change_Button.Size = new System.Drawing.Size(145, 32);
            this.Change_Button.TabIndex = 13;
            this.Change_Button.Text = "Change path";
            this.Change_Button.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.Change_Button.UseVisualStyleBackColor = true;
            this.Change_Button.Click += new System.EventHandler(this.Change_Button_Click);
            // 
            // DownloadButton
            // 
            this.DownloadButton.FlatAppearance.BorderSize = 0;
            this.DownloadButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.DownloadButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.DownloadButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.DownloadButton.Image = global::UI.Properties.Resources.DownloadFromControl;
            this.DownloadButton.Location = new System.Drawing.Point(864, 10);
            this.DownloadButton.Name = "DownloadButton";
            this.DownloadButton.Size = new System.Drawing.Size(89, 28);
            this.DownloadButton.TabIndex = 14;
            this.DownloadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.DownloadButton.UseVisualStyleBackColor = true;
            this.DownloadButton.Click += new System.EventHandler(this.DownloadButton_Click);
            // 
            // Type_box
            // 
            this.Type_box.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Type_box.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Type_box.FormattingEnabled = true;
            this.Type_box.Items.AddRange(new object[] {
            "Audio",
            "Video",
            "Mixed"});
            this.Type_box.Location = new System.Drawing.Point(18, 9);
            this.Type_box.MaxDropDownItems = 99;
            this.Type_box.Name = "Type_box";
            this.Type_box.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Type_box.Size = new System.Drawing.Size(121, 29);
            this.Type_box.TabIndex = 13;
            this.Type_box.Text = "Type";
            this.Type_box.SelectedIndexChanged += new System.EventHandler(this.Type_box_SelectedIndexChanged);
            // 
            // ClearButton
            // 
            this.ClearButton.FlatAppearance.BorderSize = 0;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ClearButton.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ClearButton.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClearButton.Location = new System.Drawing.Point(614, 8);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(89, 27);
            this.ClearButton.TabIndex = 12;
            this.ClearButton.Text = "Clear";
            this.ClearButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Quality_Box
            // 
            this.Quality_Box.Enabled = false;
            this.Quality_Box.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Quality_Box.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Quality_Box.FormattingEnabled = true;
            this.Quality_Box.Items.AddRange(new object[] {
            "Best",
            "Worst",
            "Medium",
            "Low",
            "High"});
            this.Quality_Box.Location = new System.Drawing.Point(301, 9);
            this.Quality_Box.MaxDropDownItems = 99;
            this.Quality_Box.Name = "Quality_Box";
            this.Quality_Box.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Quality_Box.Size = new System.Drawing.Size(121, 29);
            this.Quality_Box.TabIndex = 11;
            this.Quality_Box.Text = "Quality";
            this.Quality_Box.SelectedIndexChanged += new System.EventHandler(this.Quality_Box_SelectedIndexChanged);
            // 
            // TagBox
            // 
            this.TagBox.AutoSize = true;
            this.TagBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.TagBox.FlatAppearance.BorderSize = 0;
            this.TagBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.TagBox.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.TagBox.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.TagBox.Location = new System.Drawing.Point(445, 10);
            this.TagBox.Name = "TagBox";
            this.TagBox.Size = new System.Drawing.Size(163, 26);
            this.TagBox.TabIndex = 10;
            this.TagBox.Text = "Tag (if possible)";
            this.TagBox.UseVisualStyleBackColor = false;
            this.TagBox.CheckedChanged += new System.EventHandler(this.TagBox_CheckedChanged);
            // 
            // Format_box
            // 
            this.Format_box.Enabled = false;
            this.Format_box.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Format_box.ForeColor = System.Drawing.SystemColors.InfoText;
            this.Format_box.FormattingEnabled = true;
            this.Format_box.Location = new System.Drawing.Point(159, 9);
            this.Format_box.MaxDropDownItems = 99;
            this.Format_box.Name = "Format_box";
            this.Format_box.Size = new System.Drawing.Size(121, 29);
            this.Format_box.TabIndex = 2;
            this.Format_box.Text = "Format";
            this.Format_box.SelectedIndexChanged += new System.EventHandler(this.Format_box_SelectedIndexChanged);
            // 
            // FolderBrowser
            // 
            this.FolderBrowser.Description = "Choose a path where to download the files.";
            // 
            // Videos_UserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.Controls.Add(this.AllBox);
            this.Controls.Add(this.VideoGridView);
            this.Controls.Add(this.panel1);
            this.Name = "Videos_UserControl";
            this.Size = new System.Drawing.Size(957, 429);
            ((System.ComponentModel.ISupportInitialize)(this.VideoGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public  System.Windows.Forms.DataGridView VideoGridView;
        public System.Windows.Forms.CheckBox AllBox;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.ComboBox Format_box;
        public System.Windows.Forms.ComboBox Quality_Box;
        private System.Windows.Forms.CheckBox TagBox;
        private System.Windows.Forms.Button ClearButton;
        public System.Windows.Forms.ComboBox Type_box;
        private System.Windows.Forms.Button DownloadButton;
        private System.Windows.Forms.DataGridViewCheckBoxColumn CheckBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nr;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Title;
        private System.Windows.Forms.DataGridViewComboBoxColumn Download;
        private System.Windows.Forms.Button Change_Button;
        private System.Windows.Forms.FolderBrowserDialog FolderBrowser;
    }
}
