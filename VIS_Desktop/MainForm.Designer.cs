namespace VIS_Desktop
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelSigned = new System.Windows.Forms.Label();
            this.labelRole = new System.Windows.Forms.Label();
            this.btnAddEvent = new System.Windows.Forms.Button();
            this.btnEventSignIn = new System.Windows.Forms.Button();
            this.eventsListBox = new System.Windows.Forms.CheckedListBox();
            this.btnChangeInf = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.checkedListBoxSignedOn = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRemovePerson = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCSVExport = new System.Windows.Forms.Button();
            this.btnCustomSQL = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upcoming Events:";
            // 
            // labelSigned
            // 
            this.labelSigned.AutoSize = true;
            this.labelSigned.Location = new System.Drawing.Point(690, 9);
            this.labelSigned.Name = "labelSigned";
            this.labelSigned.Size = new System.Drawing.Size(43, 13);
            this.labelSigned.TabIndex = 2;
            this.labelSigned.Text = "Signed:";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(690, 35);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(32, 13);
            this.labelRole.TabIndex = 3;
            this.labelRole.Text = "Role:";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(28, 48);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(70, 23);
            this.btnAddEvent.TabIndex = 4;
            this.btnAddEvent.Text = "Add Event";
            this.btnAddEvent.UseVisualStyleBackColor = true;
            this.btnAddEvent.Visible = false;
            this.btnAddEvent.Click += new System.EventHandler(this.btnAddEvent_Click);
            // 
            // btnEventSignIn
            // 
            this.btnEventSignIn.Location = new System.Drawing.Point(31, 367);
            this.btnEventSignIn.Name = "btnEventSignIn";
            this.btnEventSignIn.Size = new System.Drawing.Size(126, 23);
            this.btnEventSignIn.TabIndex = 5;
            this.btnEventSignIn.Text = "Sign in to events";
            this.btnEventSignIn.UseVisualStyleBackColor = true;
            this.btnEventSignIn.Click += new System.EventHandler(this.btnEventSignIn_Click);
            // 
            // eventsListBox
            // 
            this.eventsListBox.FormattingEnabled = true;
            this.eventsListBox.Location = new System.Drawing.Point(31, 102);
            this.eventsListBox.Name = "eventsListBox";
            this.eventsListBox.Size = new System.Drawing.Size(302, 259);
            this.eventsListBox.TabIndex = 7;
            // 
            // btnChangeInf
            // 
            this.btnChangeInf.Location = new System.Drawing.Point(6, 19);
            this.btnChangeInf.Name = "btnChangeInf";
            this.btnChangeInf.Size = new System.Drawing.Size(119, 23);
            this.btnChangeInf.TabIndex = 8;
            this.btnChangeInf.Text = "Change Information";
            this.btnChangeInf.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(258, 78);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 9;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // checkedListBoxSignedOn
            // 
            this.checkedListBoxSignedOn.FormattingEnabled = true;
            this.checkedListBoxSignedOn.Location = new System.Drawing.Point(348, 102);
            this.checkedListBoxSignedOn.Name = "checkedListBoxSignedOn";
            this.checkedListBoxSignedOn.Size = new System.Drawing.Size(302, 259);
            this.checkedListBoxSignedOn.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(363, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Your signed in events:";
            // 
            // btnRemovePerson
            // 
            this.btnRemovePerson.Location = new System.Drawing.Point(348, 367);
            this.btnRemovePerson.Name = "btnRemovePerson";
            this.btnRemovePerson.Size = new System.Drawing.Size(126, 23);
            this.btnRemovePerson.TabIndex = 12;
            this.btnRemovePerson.Text = "Remove me from event";
            this.btnRemovePerson.UseVisualStyleBackColor = true;
            this.btnRemovePerson.Click += new System.EventHandler(this.btnRemovePerson_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnChangeInf);
            this.groupBox1.Controls.Add(this.btnAddEvent);
            this.groupBox1.Location = new System.Drawing.Point(693, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 373);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // btnCSVExport
            // 
            this.btnCSVExport.Location = new System.Drawing.Point(559, 367);
            this.btnCSVExport.Name = "btnCSVExport";
            this.btnCSVExport.Size = new System.Drawing.Size(91, 23);
            this.btnCSVExport.TabIndex = 14;
            this.btnCSVExport.Text = "Export to CSV";
            this.btnCSVExport.UseVisualStyleBackColor = true;
            this.btnCSVExport.Click += new System.EventHandler(this.btnCSVExport_Click);
            // 
            // btnCustomSQL
            // 
            this.btnCustomSQL.Location = new System.Drawing.Point(13, 13);
            this.btnCustomSQL.Name = "btnCustomSQL";
            this.btnCustomSQL.Size = new System.Drawing.Size(75, 23);
            this.btnCustomSQL.TabIndex = 15;
            this.btnCustomSQL.Text = "CustomSQL";
            this.btnCustomSQL.UseVisualStyleBackColor = true;
            this.btnCustomSQL.Click += new System.EventHandler(this.btnCustomSQL_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 450);
            this.Controls.Add(this.btnCustomSQL);
            this.Controls.Add(this.btnCSVExport);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnRemovePerson);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.checkedListBoxSignedOn);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.eventsListBox);
            this.Controls.Add(this.btnEventSignIn);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelSigned);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelSigned;
        public System.Windows.Forms.Label labelRole;
        private System.Windows.Forms.Button btnAddEvent;
        private System.Windows.Forms.Button btnEventSignIn;
        private System.Windows.Forms.CheckedListBox eventsListBox;
        private System.Windows.Forms.Button btnChangeInf;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.CheckedListBox checkedListBoxSignedOn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRemovePerson;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCSVExport;
        private System.Windows.Forms.Button btnCustomSQL;
    }
}