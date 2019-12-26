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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Upcoming Events:";
            // 
            // labelSigned
            // 
            this.labelSigned.AutoSize = true;
            this.labelSigned.Location = new System.Drawing.Point(647, 11);
            this.labelSigned.Name = "labelSigned";
            this.labelSigned.Size = new System.Drawing.Size(43, 13);
            this.labelSigned.TabIndex = 2;
            this.labelSigned.Text = "Signed:";
            // 
            // labelRole
            // 
            this.labelRole.AutoSize = true;
            this.labelRole.Location = new System.Drawing.Point(647, 37);
            this.labelRole.Name = "labelRole";
            this.labelRole.Size = new System.Drawing.Size(32, 13);
            this.labelRole.TabIndex = 3;
            this.labelRole.Text = "Role:";
            // 
            // btnAddEvent
            // 
            this.btnAddEvent.Location = new System.Drawing.Point(157, 70);
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
            this.btnEventSignIn.Location = new System.Drawing.Point(31, 378);
            this.btnEventSignIn.Name = "btnEventSignIn";
            this.btnEventSignIn.Size = new System.Drawing.Size(91, 23);
            this.btnEventSignIn.TabIndex = 5;
            this.btnEventSignIn.Text = "Sign in to event";
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
            this.btnChangeInf.Location = new System.Drawing.Point(650, 65);
            this.btnChangeInf.Name = "btnChangeInf";
            this.btnChangeInf.Size = new System.Drawing.Size(119, 23);
            this.btnChangeInf.TabIndex = 8;
            this.btnChangeInf.Text = "Change Information";
            this.btnChangeInf.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChangeInf);
            this.Controls.Add(this.eventsListBox);
            this.Controls.Add(this.btnEventSignIn);
            this.Controls.Add(this.btnAddEvent);
            this.Controls.Add(this.labelRole);
            this.Controls.Add(this.labelSigned);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
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
    }
}