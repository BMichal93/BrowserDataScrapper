namespace BrowserDataScrapperInstaller
{
    partial class frm_Installer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_Installer));
            this.tc_MainTabs = new System.Windows.Forms.TabControl();
            this.tbp_WelcomePage = new System.Windows.Forms.TabPage();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.pic_WizardWand = new System.Windows.Forms.PictureBox();
            this.txt_Introduction = new System.Windows.Forms.RichTextBox();
            this.tbp_InstallPage = new System.Windows.Forms.TabPage();
            this.tc_MainTabs.SuspendLayout();
            this.tbp_WelcomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_WizardWand)).BeginInit();
            this.SuspendLayout();
            // 
            // tc_MainTabs
            // 
            this.tc_MainTabs.Controls.Add(this.tbp_WelcomePage);
            this.tc_MainTabs.Controls.Add(this.tbp_InstallPage);
            this.tc_MainTabs.Location = new System.Drawing.Point(3, 4);
            this.tc_MainTabs.Name = "tc_MainTabs";
            this.tc_MainTabs.SelectedIndex = 0;
            this.tc_MainTabs.Size = new System.Drawing.Size(785, 424);
            this.tc_MainTabs.TabIndex = 0;
            // 
            // tbp_WelcomePage
            // 
            this.tbp_WelcomePage.Controls.Add(this.btn_Cancel);
            this.tbp_WelcomePage.Controls.Add(this.btn_Next);
            this.tbp_WelcomePage.Controls.Add(this.pic_WizardWand);
            this.tbp_WelcomePage.Controls.Add(this.txt_Introduction);
            this.tbp_WelcomePage.Location = new System.Drawing.Point(4, 22);
            this.tbp_WelcomePage.Name = "tbp_WelcomePage";
            this.tbp_WelcomePage.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_WelcomePage.Size = new System.Drawing.Size(777, 398);
            this.tbp_WelcomePage.TabIndex = 0;
            this.tbp_WelcomePage.Text = "Welcome!";
            this.tbp_WelcomePage.UseVisualStyleBackColor = true;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Cancel.Location = new System.Drawing.Point(532, 343);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(108, 49);
            this.btn_Cancel.TabIndex = 3;
            this.btn_Cancel.Text = "CANCEL";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_Next.Location = new System.Drawing.Point(646, 343);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(108, 49);
            this.btn_Next.TabIndex = 2;
            this.btn_Next.Text = "NEXT";
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            // 
            // pic_WizardWand
            // 
            this.pic_WizardWand.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pic_WizardWand.Image = global::BrowserDataScrapperInstaller.Properties.Resources.WandIcon;
            this.pic_WizardWand.InitialImage = ((System.Drawing.Image)(resources.GetObject("pic_WizardWand.InitialImage")));
            this.pic_WizardWand.Location = new System.Drawing.Point(500, 19);
            this.pic_WizardWand.Name = "pic_WizardWand";
            this.pic_WizardWand.Size = new System.Drawing.Size(254, 162);
            this.pic_WizardWand.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_WizardWand.TabIndex = 1;
            this.pic_WizardWand.TabStop = false;
            this.pic_WizardWand.WaitOnLoad = true;
            // 
            // txt_Introduction
            // 
            this.txt_Introduction.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txt_Introduction.Enabled = false;
            this.txt_Introduction.Location = new System.Drawing.Point(19, 19);
            this.txt_Introduction.Name = "txt_Introduction";
            this.txt_Introduction.Size = new System.Drawing.Size(459, 132);
            this.txt_Introduction.TabIndex = 0;
            this.txt_Introduction.Text = resources.GetString("txt_Introduction.Text");
            // 
            // tbp_InstallPage
            // 
            this.tbp_InstallPage.Location = new System.Drawing.Point(4, 22);
            this.tbp_InstallPage.Name = "tbp_InstallPage";
            this.tbp_InstallPage.Padding = new System.Windows.Forms.Padding(3);
            this.tbp_InstallPage.Size = new System.Drawing.Size(777, 398);
            this.tbp_InstallPage.TabIndex = 1;
            this.tbp_InstallPage.Text = "Installation";
            this.tbp_InstallPage.UseVisualStyleBackColor = true;
            // 
            // frm_Installer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tc_MainTabs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frm_Installer";
            this.Text = "Installer";
            this.tc_MainTabs.ResumeLayout(false);
            this.tbp_WelcomePage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_WizardWand)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tc_MainTabs;
        private System.Windows.Forms.TabPage tbp_WelcomePage;
        private System.Windows.Forms.TabPage tbp_InstallPage;
        private System.Windows.Forms.RichTextBox txt_Introduction;
        private System.Windows.Forms.PictureBox pic_WizardWand;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_Next;
    }
}

