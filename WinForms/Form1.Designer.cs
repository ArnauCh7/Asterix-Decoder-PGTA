namespace WinForms
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnTopBar = new Panel();
            label1 = new Label();
            sideButton = new PictureBox();
            sidebar = new FlowLayoutPanel();
            pnHome = new Panel();
            HomeButton = new Button();
            pnImport = new Panel();
            ImportButton = new Button();
            pnDisplay = new Panel();
            DisplayButton = new Button();
            pnSim = new Panel();
            SimulationButton = new Button();
            pnHelp = new Panel();
            HelpButton = new Button();
            sidebarTransition = new System.Windows.Forms.Timer(components);
            pnP3 = new Panel();
            P3Button = new Button();
            pnTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sideButton).BeginInit();
            sidebar.SuspendLayout();
            pnHome.SuspendLayout();
            pnImport.SuspendLayout();
            pnDisplay.SuspendLayout();
            pnSim.SuspendLayout();
            pnHelp.SuspendLayout();
            pnP3.SuspendLayout();
            SuspendLayout();
            // 
            // pnTopBar
            // 
            pnTopBar.BackColor = SystemColors.Control;
            pnTopBar.Controls.Add(label1);
            pnTopBar.Controls.Add(sideButton);
            pnTopBar.Dock = DockStyle.Top;
            pnTopBar.Location = new System.Drawing.Point(0, 0);
            pnTopBar.Name = "pnTopBar";
            pnTopBar.Size = new System.Drawing.Size(984, 38);
            pnTopBar.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(40, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(49, 17);
            label1.TabIndex = 2;
            label1.Text = "MENU";
            // 
            // sideButton
            // 
            sideButton.Image = (System.Drawing.Image)resources.GetObject("sideButton.Image");
            sideButton.Location = new System.Drawing.Point(3, 3);
            sideButton.Name = "sideButton";
            sideButton.Size = new System.Drawing.Size(31, 32);
            sideButton.SizeMode = PictureBoxSizeMode.CenterImage;
            sideButton.TabIndex = 1;
            sideButton.TabStop = false;
            sideButton.Click += sideButton_Click_1;
            // 
            // sidebar
            // 
            sidebar.BackColor = System.Drawing.Color.CornflowerBlue;
            sidebar.Controls.Add(pnHome);
            sidebar.Controls.Add(pnImport);
            sidebar.Controls.Add(pnDisplay);
            sidebar.Controls.Add(pnSim);
            sidebar.Controls.Add(pnHelp);
            sidebar.Controls.Add(pnP3);
            sidebar.Dock = DockStyle.Left;
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.Location = new System.Drawing.Point(0, 38);
            sidebar.Name = "sidebar";
            sidebar.Size = new System.Drawing.Size(40, 473);
            sidebar.TabIndex = 1;
            // 
            // pnHome
            // 
            pnHome.BackColor = System.Drawing.Color.CornflowerBlue;
            pnHome.Controls.Add(HomeButton);
            pnHome.Location = new System.Drawing.Point(3, 3);
            pnHome.Name = "pnHome";
            pnHome.Size = new System.Drawing.Size(279, 53);
            pnHome.TabIndex = 4;
            // 
            // HomeButton
            // 
            HomeButton.BackColor = System.Drawing.Color.CornflowerBlue;
            HomeButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            HomeButton.Image = (System.Drawing.Image)resources.GetObject("HomeButton.Image");
            HomeButton.ImageAlign = ContentAlignment.MiddleLeft;
            HomeButton.Location = new System.Drawing.Point(-8, -16);
            HomeButton.Margin = new Padding(0);
            HomeButton.Name = "HomeButton";
            HomeButton.Padding = new Padding(4, 0, 0, 0);
            HomeButton.Size = new System.Drawing.Size(298, 87);
            HomeButton.TabIndex = 2;
            HomeButton.Text = "         Home";
            HomeButton.TextAlign = ContentAlignment.MiddleLeft;
            HomeButton.UseVisualStyleBackColor = false;
            HomeButton.Click += HomeButton_Click;
            // 
            // pnImport
            // 
            pnImport.Controls.Add(ImportButton);
            pnImport.Location = new System.Drawing.Point(3, 62);
            pnImport.Name = "pnImport";
            pnImport.Size = new System.Drawing.Size(279, 53);
            pnImport.TabIndex = 5;
            // 
            // ImportButton
            // 
            ImportButton.BackColor = System.Drawing.Color.CornflowerBlue;
            ImportButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            ImportButton.Image = (System.Drawing.Image)resources.GetObject("ImportButton.Image");
            ImportButton.ImageAlign = ContentAlignment.MiddleLeft;
            ImportButton.Location = new System.Drawing.Point(-8, -16);
            ImportButton.Name = "ImportButton";
            ImportButton.Padding = new Padding(4, 0, 0, 0);
            ImportButton.Size = new System.Drawing.Size(298, 87);
            ImportButton.TabIndex = 2;
            ImportButton.Text = "         Import File";
            ImportButton.TextAlign = ContentAlignment.MiddleLeft;
            ImportButton.UseVisualStyleBackColor = false;
            ImportButton.Click += ImportButton_Click;
            // 
            // pnDisplay
            // 
            pnDisplay.Controls.Add(DisplayButton);
            pnDisplay.Location = new System.Drawing.Point(3, 121);
            pnDisplay.Name = "pnDisplay";
            pnDisplay.Size = new System.Drawing.Size(279, 53);
            pnDisplay.TabIndex = 4;
            // 
            // DisplayButton
            // 
            DisplayButton.BackColor = System.Drawing.Color.CornflowerBlue;
            DisplayButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            DisplayButton.Image = (System.Drawing.Image)resources.GetObject("DisplayButton.Image");
            DisplayButton.ImageAlign = ContentAlignment.MiddleLeft;
            DisplayButton.Location = new System.Drawing.Point(-8, -16);
            DisplayButton.Name = "DisplayButton";
            DisplayButton.Padding = new Padding(4, 0, 0, 0);
            DisplayButton.Size = new System.Drawing.Size(298, 87);
            DisplayButton.TabIndex = 2;
            DisplayButton.Text = "         Display";
            DisplayButton.TextAlign = ContentAlignment.MiddleLeft;
            DisplayButton.UseVisualStyleBackColor = false;
            DisplayButton.Click += DisplayButton_Click;
            // 
            // pnSim
            // 
            pnSim.Controls.Add(SimulationButton);
            pnSim.Location = new System.Drawing.Point(3, 180);
            pnSim.Name = "pnSim";
            pnSim.Size = new System.Drawing.Size(279, 53);
            pnSim.TabIndex = 5;
            // 
            // SimulationButton
            // 
            SimulationButton.BackColor = System.Drawing.Color.CornflowerBlue;
            SimulationButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            SimulationButton.Image = (System.Drawing.Image)resources.GetObject("SimulationButton.Image");
            SimulationButton.ImageAlign = ContentAlignment.MiddleLeft;
            SimulationButton.Location = new System.Drawing.Point(-8, -16);
            SimulationButton.Name = "SimulationButton";
            SimulationButton.Padding = new Padding(5, 0, 0, 0);
            SimulationButton.Size = new System.Drawing.Size(298, 87);
            SimulationButton.TabIndex = 2;
            SimulationButton.Text = "         Simulation";
            SimulationButton.TextAlign = ContentAlignment.MiddleLeft;
            SimulationButton.UseVisualStyleBackColor = false;
            SimulationButton.Click += SimulationButton_Click;
            // 
            // pnHelp
            // 
            pnHelp.Controls.Add(HelpButton);
            pnHelp.Location = new System.Drawing.Point(3, 239);
            pnHelp.Name = "pnHelp";
            pnHelp.Size = new System.Drawing.Size(279, 53);
            pnHelp.TabIndex = 6;
            // 
            // HelpButton
            // 
            HelpButton.BackColor = System.Drawing.Color.CornflowerBlue;
            HelpButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            HelpButton.Image = (System.Drawing.Image)resources.GetObject("HelpButton.Image");
            HelpButton.ImageAlign = ContentAlignment.MiddleLeft;
            HelpButton.Location = new System.Drawing.Point(-8, -16);
            HelpButton.Name = "HelpButton";
            HelpButton.Padding = new Padding(5, 0, 0, 0);
            HelpButton.Size = new System.Drawing.Size(298, 87);
            HelpButton.TabIndex = 2;
            HelpButton.Text = "         Help";
            HelpButton.TextAlign = ContentAlignment.MiddleLeft;
            HelpButton.UseVisualStyleBackColor = false;
            HelpButton.Click += HelpButton_Click;
            // 
            // sidebarTransition
            // 
            sidebarTransition.Interval = 1;
            sidebarTransition.Tick += sidebarTransition_Tick_1;
            // 
            // pnP3
            // 
            pnP3.Controls.Add(P3Button);
            pnP3.Location = new System.Drawing.Point(3, 298);
            pnP3.Name = "pnP3";
            pnP3.Size = new System.Drawing.Size(279, 53);
            pnP3.TabIndex = 7;
            // 
            // P3Button
            // 
            P3Button.BackColor = System.Drawing.Color.CornflowerBlue;
            P3Button.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            P3Button.Image = (System.Drawing.Image)resources.GetObject("P3Button.Image");
            P3Button.ImageAlign = ContentAlignment.MiddleLeft;
            P3Button.Location = new System.Drawing.Point(-8, -16);
            P3Button.Name = "P3Button";
            P3Button.Padding = new Padding(5, 0, 0, 0);
            P3Button.Size = new System.Drawing.Size(298, 87);
            P3Button.TabIndex = 2;
            P3Button.Text = "         Statistics";
            P3Button.TextAlign = ContentAlignment.MiddleLeft;
            P3Button.UseVisualStyleBackColor = false;
            P3Button.Click += P3Button_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(984, 511);
            Controls.Add(sidebar);
            Controls.Add(pnTopBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Name = "Form1";
            Text = "Asterix Decoder";
            Load += Form1_Load;
            pnTopBar.ResumeLayout(false);
            pnTopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)sideButton).EndInit();
            sidebar.ResumeLayout(false);
            pnHome.ResumeLayout(false);
            pnImport.ResumeLayout(false);
            pnDisplay.ResumeLayout(false);
            pnSim.ResumeLayout(false);
            pnHelp.ResumeLayout(false);
            pnP3.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnTopBar;
        private PictureBox sideButton;
        private Label label1;
        private System.CodeDom.CodeTypeReference nightControlBox1;
        private FlowLayoutPanel sidebar;
        private Panel pnDisplay;
        private Button DisplayButton;
        private Panel pnSim;
        private Button SimulationButton;
        private Panel pnImport;
        private Button ImportButton;
        private System.Windows.Forms.Timer sidebarTransition;
        private Panel pnHome;
        private Button HomeButton;
        private Panel pnHelp;
        private Button HelpButton;
        private Panel pnP3;
        private Button P3Button;
    }
}