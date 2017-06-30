namespace SolrConfiguration.UI.Windows
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.goButton = new System.Windows.Forms.Button();
            this.sourceConfigFolder = new System.Windows.Forms.TextBox();
            this.targetConfigSetFolder = new System.Windows.Forms.TextBox();
            this.targetFolderSuffixes = new System.Windows.Forms.TextBox();
            this.targetFolderPrefix = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(811, 767);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(299, 105);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "Go";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // sourceConfigFolder
            // 
            this.sourceConfigFolder.Location = new System.Drawing.Point(119, 81);
            this.sourceConfigFolder.Name = "sourceConfigFolder";
            this.sourceConfigFolder.Size = new System.Drawing.Size(991, 38);
            this.sourceConfigFolder.TabIndex = 1;
            this.sourceConfigFolder.Text = "C:\\Bitnami\\solr-6.6.0-0\\apache-solr\\server\\solr\\sitecore_BASELINE_index";
            // 
            // targetConfigSetFolder
            // 
            this.targetConfigSetFolder.Location = new System.Drawing.Point(119, 186);
            this.targetConfigSetFolder.Name = "targetConfigSetFolder";
            this.targetConfigSetFolder.Size = new System.Drawing.Size(991, 38);
            this.targetConfigSetFolder.TabIndex = 2;
            this.targetConfigSetFolder.Text = "C:\\Bitnami\\solr-6.6.0-0\\apache-solr\\server\\solr";
            // 
            // targetFolderSuffixes
            // 
            this.targetFolderSuffixes.Location = new System.Drawing.Point(119, 429);
            this.targetFolderSuffixes.Multiline = true;
            this.targetFolderSuffixes.Name = "targetFolderSuffixes";
            this.targetFolderSuffixes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.targetFolderSuffixes.Size = new System.Drawing.Size(991, 305);
            this.targetFolderSuffixes.TabIndex = 3;
            this.targetFolderSuffixes.Text = resources.GetString("targetFolderSuffixes.Text");
            // 
            // targetFolderPrefix
            // 
            this.targetFolderPrefix.Location = new System.Drawing.Point(119, 303);
            this.targetFolderPrefix.Name = "targetFolderPrefix";
            this.targetFolderPrefix.Size = new System.Drawing.Size(577, 38);
            this.targetFolderPrefix.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(113, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 32);
            this.label1.TabIndex = 5;
            this.label1.Text = "Source Config Folder";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(113, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(318, 32);
            this.label2.TabIndex = 6;
            this.label2.Text = "Target ConfigSet Folder";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(113, 259);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(265, 32);
            this.label3.TabIndex = 7;
            this.label3.Text = "Target Folder Prefix";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(113, 385);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 32);
            this.label4.TabIndex = 8;
            this.label4.Text = "Target Folder Suffixes";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 930);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.targetFolderPrefix);
            this.Controls.Add(this.targetFolderSuffixes);
            this.Controls.Add(this.targetConfigSetFolder);
            this.Controls.Add(this.sourceConfigFolder);
            this.Controls.Add(this.goButton);
            this.Name = "Main";
            this.Text = "Solr Configuration Copy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox sourceConfigFolder;
        private System.Windows.Forms.TextBox targetConfigSetFolder;
        private System.Windows.Forms.TextBox targetFolderSuffixes;
        private System.Windows.Forms.TextBox targetFolderPrefix;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

