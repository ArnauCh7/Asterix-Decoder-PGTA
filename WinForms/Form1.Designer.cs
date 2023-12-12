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
            pnTopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)sideButton).BeginInit();
            sidebar.SuspendLayout();
            pnHome.SuspendLayout();
            pnImport.SuspendLayout();
            pnDisplay.SuspendLayout();
            pnSim.SuspendLayout();
            pnHelp.SuspendLayout();
            SuspendLayout();
            // 
            // pnTopBar
            // 
            pnTopBar.BackColor = SystemColors.Control;
            pnTopBar.Controls.Add(label1);
            pnTopBar.Controls.Add(sideButton);
            pnTopBar.Dock = DockStyle.Top;
            pnTopBar.Location = new Point(0, 0);
            pnTopBar.Margin = new Padding(3, 4, 3, 4);
            pnTopBar.Name = "pnTopBar";
            pnTopBar.Size = new Size(1125, 51);
            pnTopBar.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(46, 12);
            label1.Name = "label1";
            label1.Size = new Size(63, 23);
            label1.TabIndex = 2;
            label1.Text = "MENU";
            // 
            // sideButton
            // 
            sideButton.Image = (Image)resources.GetObject("sideButton.Image");
            sideButton.Location = new Point(3, 4);
            sideButton.Margin = new Padding(3, 4, 3, 4);
            sideButton.Name = "sideButton";
            sideButton.Size = new Size(35, 43);
            sideButton.SizeMode = PictureBoxSizeMode.CenterImage;
            sideButton.TabIndex = 1;
            sideButton.TabStop = false;
            sideButton.Click += sideButton_Click_1;
            // 
            // sidebar
            // 
            sidebar.BackColor = Color.CornflowerBlue;
            sidebar.Controls.Add(pnHome);
            sidebar.Controls.Add(pnImport);
            sidebar.Controls.Add(pnDisplay);
            sidebar.Controls.Add(pnSim);
            sidebar.Controls.Add(pnHelp);
            sidebar.Dock = DockStyle.Left;
            sidebar.FlowDirection = FlowDirection.TopDown;
            sidebar.Location = new Point(0, 51);
            sidebar.Margin = new Padding(3, 4, 3, 4);
            sidebar.Name = "sidebar";
            sidebar.Size = new Size(46, 630);
            sidebar.TabIndex = 1;
            // 
            // pnHome
            // 
            pnHome.BackColor = Color.CornflowerBlue;
            pnHome.Controls.Add(HomeButton);
            pnHome.Location = new Point(3, 4);
            pnHome.Margin = new Padding(3, 4, 3, 4);
            pnHome.Name = "pnHome";
            pnHome.Size = new Size(319, 71);
            pnHome.TabIndex = 4;
            // 
            // HomeButton
            // 
            HomeButton.BackColor = Color.CornflowerBlue;
            HomeButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            HomeButton.Image = (Image)resources.GetObject("HomeButton.Image");
            HomeButton.ImageAlign = ContentAlignment.MiddleLeft;
            HomeButton.Location = new Point(-9, -21);
            HomeButton.Margin = new Padding(0);
            HomeButton.Name = "HomeButton";
            HomeButton.Padding = new Padding(5, 0, 0, 0);
            HomeButton.Size = new Size(341, 116);
            HomeButton.TabIndex = 2;
            HomeButton.Text = "         Home";
            HomeButton.TextAlign = ContentAlignment.MiddleLeft;
            HomeButton.UseVisualStyleBackColor = false;
            HomeButton.Click += HomeButton_Click;
            // 
            // pnImport
            // 
            pnImport.Controls.Add(ImportButton);
            pnImport.Location = new Point(3, 83);
            pnImport.Margin = new Padding(3, 4, 3, 4);
            pnImport.Name = "pnImport";
            pnImport.Size = new Size(319, 71);
            pnImport.TabIndex = 5;
            // 
            // ImportButton
            // 
            ImportButton.BackColor = Color.CornflowerBlue;
            ImportButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            ImportButton.Image = (Image)resources.GetObject("ImportButton.Image");
            ImportButton.ImageAlign = ContentAlignment.MiddleLeft;
            ImportButton.Location = new Point(-9, -21);
            ImportButton.Margin = new Padding(3, 4, 3, 4);
            ImportButton.Name = "ImportButton";
            ImportButton.Padding = new Padding(5, 0, 0, 0);
            ImportButton.Size = new Size(341, 116);
            ImportButton.TabIndex = 2;
            ImportButton.Text = "         Import File";
            ImportButton.TextAlign = ContentAlignment.MiddleLeft;
            ImportButton.UseVisualStyleBackColor = false;
            ImportButton.Click += ImportButton_Click;
            // 
            // pnDisplay
            // 
            pnDisplay.Controls.Add(DisplayButton);
            pnDisplay.Location = new Point(3, 162);
            pnDisplay.Margin = new Padding(3, 4, 3, 4);
            pnDisplay.Name = "pnDisplay";
            pnDisplay.Size = new Size(319, 71);
            pnDisplay.TabIndex = 4;
            // 
            // DisplayButton
            // 
            DisplayButton.BackColor = Color.CornflowerBlue;
            DisplayButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            DisplayButton.Image = (Image)resources.GetObject("DisplayButton.Image");
            DisplayButton.ImageAlign = ContentAlignment.MiddleLeft;
            DisplayButton.Location = new Point(-9, -21);
            DisplayButton.Margin = new Padding(3, 4, 3, 4);
            DisplayButton.Name = "DisplayButton";
            DisplayButton.Padding = new Padding(5, 0, 0, 0);
            DisplayButton.Size = new Size(341, 116);
            DisplayButton.TabIndex = 2;
            DisplayButton.Text = "         Display";
            DisplayButton.TextAlign = ContentAlignment.MiddleLeft;
            DisplayButton.UseVisualStyleBackColor = false;
            DisplayButton.Click += DisplayButton_Click;
            // 
            // pnSim
            // 
            pnSim.Controls.Add(SimulationButton);
            pnSim.Location = new Point(3, 241);
            pnSim.Margin = new Padding(3, 4, 3, 4);
            pnSim.Name = "pnSim";
            pnSim.Size = new Size(319, 71);
            pnSim.TabIndex = 5;
            // 
            // SimulationButton
            // 
            SimulationButton.BackColor = Color.CornflowerBlue;
            SimulationButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            SimulationButton.Image = (Image)resources.GetObject("SimulationButton.Image");
            SimulationButton.ImageAlign = ContentAlignment.MiddleLeft;
            SimulationButton.Location = new Point(-9, -21);
            SimulationButton.Margin = new Padding(3, 4, 3, 4);
            SimulationButton.Name = "SimulationButton";
            SimulationButton.Padding = new Padding(6, 0, 0, 0);
            SimulationButton.Size = new Size(341, 116);
            SimulationButton.TabIndex = 2;
            SimulationButton.Text = "         Simulation";
            SimulationButton.TextAlign = ContentAlignment.MiddleLeft;
            SimulationButton.UseVisualStyleBackColor = false;
            SimulationButton.Click += SimulationButton_Click;
            // 
            // pnHelp
            // 
            pnHelp.Controls.Add(HelpButton);
            pnHelp.Location = new Point(3, 320);
            pnHelp.Margin = new Padding(3, 4, 3, 4);
            pnHelp.Name = "pnHelp";
            pnHelp.Size = new Size(319, 71);
            pnHelp.TabIndex = 6;
            // 
            // HelpButton
            // 
            HelpButton.BackColor = Color.CornflowerBlue;
            HelpButton.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            HelpButton.Image = (Image)resources.GetObject("HelpButton.Image");
            HelpButton.ImageAlign = ContentAlignment.MiddleLeft;
            HelpButton.Location = new Point(-9, -21);
            HelpButton.Margin = new Padding(3, 4, 3, 4);
            HelpButton.Name = "HelpButton";
            HelpButton.Padding = new Padding(6, 0, 0, 0);
            HelpButton.Size = new Size(341, 116);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1125, 681);
            Controls.Add(sidebar);
            Controls.Add(pnTopBar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            Margin = new Padding(3, 4, 3, 4);
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
    }
}