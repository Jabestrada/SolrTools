namespace SolrConfiguration.CoreBuilder.UI.Windows
{
    partial class CoreBuilder
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
            this.goButton = new System.Windows.Forms.Button();
            this.solrServerBaseUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.coresToCreate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.configFile = new System.Windows.Forms.TextBox();
            this.schemaFile = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dataDir = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.results = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // goButton
            // 
            this.goButton.Location = new System.Drawing.Point(793, 821);
            this.goButton.Name = "goButton";
            this.goButton.Size = new System.Drawing.Size(262, 90);
            this.goButton.TabIndex = 0;
            this.goButton.Text = "Create Core";
            this.goButton.UseVisualStyleBackColor = true;
            this.goButton.Click += new System.EventHandler(this.goButton_Click);
            // 
            // solrServerBaseUrl
            // 
            this.solrServerBaseUrl.Location = new System.Drawing.Point(96, 72);
            this.solrServerBaseUrl.Name = "solrServerBaseUrl";
            this.solrServerBaseUrl.Size = new System.Drawing.Size(950, 38);
            this.solrServerBaseUrl.TabIndex = 1;
            this.solrServerBaseUrl.Text = "http://localhost:8983/solr";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 32);
            this.label1.TabIndex = 2;
            this.label1.Text = "Solr Server URL";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(90, 457);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(222, 32);
            this.label2.TabIndex = 3;
            this.label2.Text = "Cores To Create";
            // 
            // coresToCreate
            // 
            this.coresToCreate.Location = new System.Drawing.Point(96, 503);
            this.coresToCreate.Multiline = true;
            this.coresToCreate.Name = "coresToCreate";
            this.coresToCreate.Size = new System.Drawing.Size(959, 289);
            this.coresToCreate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(90, 135);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 32);
            this.label3.TabIndex = 5;
            this.label3.Text = "Config File";
            // 
            // configFile
            // 
            this.configFile.Location = new System.Drawing.Point(96, 170);
            this.configFile.Name = "configFile";
            this.configFile.Size = new System.Drawing.Size(950, 38);
            this.configFile.TabIndex = 6;
            this.configFile.Text = "solrconfig.xml";
            // 
            // schemaFile
            // 
            this.schemaFile.Location = new System.Drawing.Point(96, 270);
            this.schemaFile.Name = "schemaFile";
            this.schemaFile.Size = new System.Drawing.Size(950, 38);
            this.schemaFile.TabIndex = 8;
            this.schemaFile.Text = "schema.xml";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(173, 32);
            this.label4.TabIndex = 7;
            this.label4.Text = "Schema File";
            // 
            // dataDir
            // 
            this.dataDir.Location = new System.Drawing.Point(96, 371);
            this.dataDir.Name = "dataDir";
            this.dataDir.Size = new System.Drawing.Size(950, 38);
            this.dataDir.TabIndex = 10;
            this.dataDir.Text = "data";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(90, 336);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(118, 32);
            this.label5.TabIndex = 9;
            this.label5.Text = "Data Dir";
            // 
            // results
            // 
            this.results.Location = new System.Drawing.Point(96, 957);
            this.results.Multiline = true;
            this.results.Name = "results";
            this.results.Size = new System.Drawing.Size(959, 289);
            this.results.TabIndex = 11;
            // 
            // CoreBuilder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1131, 1460);
            this.Controls.Add(this.results);
            this.Controls.Add(this.dataDir);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.schemaFile);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.configFile);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coresToCreate);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.solrServerBaseUrl);
            this.Controls.Add(this.goButton);
            this.Name = "CoreBuilder";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Solr Core Manager";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button goButton;
        private System.Windows.Forms.TextBox solrServerBaseUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox coresToCreate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox configFile;
        private System.Windows.Forms.TextBox schemaFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox dataDir;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox results;
    }
}

