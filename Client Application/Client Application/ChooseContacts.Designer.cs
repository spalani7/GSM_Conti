namespace Client_Application
{
    partial class ChooseContacts
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
            this.ContactListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // ContactListBox
            // 
            this.ContactListBox.BackColor = System.Drawing.SystemColors.MenuBar;
            this.ContactListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ContactListBox.CheckOnClick = true;
            this.ContactListBox.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ContactListBox.FormattingEnabled = true;
            this.ContactListBox.Location = new System.Drawing.Point(12, 24);
            this.ContactListBox.Name = "ContactListBox";
            this.ContactListBox.Size = new System.Drawing.Size(234, 210);
            this.ContactListBox.Sorted = true;
            this.ContactListBox.TabIndex = 0;
            // 
            // ChooseContacts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 262);
            this.Controls.Add(this.ContactListBox);
            this.Name = "ChooseContacts";
            this.Text = "Choose Contacts";
            this.Load += new System.EventHandler(this.ChooseContacts_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox ContactListBox;
    }
}