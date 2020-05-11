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
            this.btnDiteBecomeVed = new System.Windows.Forms.Button();
            this.btnInfoOVed = new System.Windows.Forms.Button();
            this.btnNejAkce = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nadcházejicí akce:";
            // 
            // labelSigned
            // 
            this.labelSigned.AutoSize = true;
            this.labelSigned.Location = new System.Drawing.Point(779, 9);
            this.labelSigned.Name = "labelSigned";
            this.labelSigned.Size = new System.Drawing.Size(54, 13);
            this.labelSigned.TabIndex = 2;
            this.labelSigned.Text = "Přihlášen:";
            this.labelSigned.Click += new System.EventHandler(this.labelSigned_Click);
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(779, 35);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(32, 13);
            this.labelRole.TabIndex = 3;
            this.labelRole.Text = "Role:";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(6, 48);
            this.btnAddEvent.Name = "btnAddEvent";
            this.btnAddEvent.Size = new System.Drawing.Size(119, 23);
            this.btnAddEvent.TabIndex = 4;
            this.btnAddEvent.Text = "Přidat akci";
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
            this.btnEventSignIn.Text = "Přihlásit mě na akce";
            this.btnEventSignIn.UseVisualStyleBackColor = true;
            this.btnEventSignIn.Click += new System.EventHandler(this.btnEventSignIn_Click);
            // 
            // eventsListBox
            // 
            this.eventsListBox.FormattingEnabled = true;
            this.eventsListBox.Location = new System.Drawing.Point(31, 102);
            this.eventsListBox.Name = "eventsListBox";
            this.eventsListBox.Size = new System.Drawing.Size(380, 259);
            this.eventsListBox.TabIndex = 7;
            // 
            // btnChangeInf
            // 
            this.btnChangeInf.Location = new System.Drawing.Point(6, 19);
            this.btnChangeInf.Name = "btnChangeInf";
            this.btnChangeInf.Size = new System.Drawing.Size(119, 23);
            this.btnChangeInf.TabIndex = 8;
            this.btnChangeInf.Text = "Změnit informace";
            this.btnChangeInf.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(336, 73);
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
            this.checkedListBoxSignedOn.Location = new System.Drawing.Point(417, 102);
            this.checkedListBoxSignedOn.Name = "checkedListBoxSignedOn";
            this.checkedListBoxSignedOn.Size = new System.Drawing.Size(359, 259);
            this.checkedListBoxSignedOn.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(432, 83);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Jsi přihlášený na tyto akce:";
            // 
            // btnRemovePerson
            // 
            this.btnRemovePerson.Location = new System.Drawing.Point(417, 367);
            this.btnRemovePerson.Name = "btnRemovePerson";
            this.btnRemovePerson.Size = new System.Drawing.Size(126, 23);
            this.btnRemovePerson.TabIndex = 12;
            this.btnRemovePerson.Text = "Odebrat mě z akcí:";
            this.btnRemovePerson.UseVisualStyleBackColor = true;
            this.btnRemovePerson.Click += new System.EventHandler(this.btnRemovePerson_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNejAkce);
            this.groupBox1.Controls.Add(this.btnInfoOVed);
            this.groupBox1.Controls.Add(this.btnDiteBecomeVed);
            this.groupBox1.Controls.Add(this.btnChangeInf);
            this.groupBox1.Controls.Add(this.btnAddEvent);
            this.groupBox1.Location = new System.Drawing.Point(782, 65);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(138, 373);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Options";
            // 
            // btnCSVExport
            // 
            this.btnCSVExport.Location = new System.Drawing.Point(685, 367);
            this.btnCSVExport.Name = "btnCSVExport";
            this.btnCSVExport.Size = new System.Drawing.Size(91, 23);
            this.btnCSVExport.TabIndex = 14;
            this.btnCSVExport.Text = "Export CSV";
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
            // btnDiteBecomeVed
            // 
            this.btnDiteBecomeVed.Location = new System.Drawing.Point(6, 77);
            this.btnDiteBecomeVed.Name = "btnDiteBecomeVed";
            this.btnDiteBecomeVed.Size = new System.Drawing.Size(119, 23);
            this.btnDiteBecomeVed.TabIndex = 9;
            this.btnDiteBecomeVed.Text = "Dítě->vedoucí";
            this.btnDiteBecomeVed.UseVisualStyleBackColor = true;
            this.btnDiteBecomeVed.Click += new System.EventHandler(this.btnDiteBecomeVed_Click);
            // 
            // btnInfoOVed
            // 
            this.btnInfoOVed.Location = new System.Drawing.Point(6, 106);
            this.btnInfoOVed.Name = "btnInfoOVed";
            this.btnInfoOVed.Size = new System.Drawing.Size(119, 23);
            this.btnInfoOVed.TabIndex = 10;
            this.btnInfoOVed.Text = "Info o vedoucím";
            this.btnInfoOVed.UseVisualStyleBackColor = true;
            this.btnInfoOVed.Click += new System.EventHandler(this.btnInfoOVed_Click);
            // 
            // btnNejAkce
            // 
            this.btnNejAkce.Location = new System.Drawing.Point(6, 135);
            this.btnNejAkce.Name = "btnNejAkce";
            this.btnNejAkce.Size = new System.Drawing.Size(119, 38);
            this.btnNejAkce.TabIndex = 11;
            this.btnNejAkce.Text = "Vyhledej dítě na nejpočetnější akci";
            this.btnNejAkce.UseVisualStyleBackColor = true;
            this.btnNejAkce.Click += new System.EventHandler(this.btnNejAkce_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 450);
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
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.Button btnDiteBecomeVed;
        private System.Windows.Forms.Button btnNejAkce;
        private System.Windows.Forms.Button btnInfoOVed;
    }
}