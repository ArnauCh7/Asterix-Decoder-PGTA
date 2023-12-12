namespace WinForms
{
    partial class formDisplay
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
            btnLoadGrid = new Button();
            advancedDataGridView1 = new Zuby.ADGV.AdvancedDataGridView();
            InitialTime = new TextBox();
            btnFilterID = new Button();
            btnClear = new Button();
            FinalTime = new TextBox();
            searchID = new TextBox();
            searchSSR = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            expCSVbtn = new Button();
            ((System.ComponentModel.ISupportInitialize)advancedDataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnLoadGrid
            // 
            btnLoadGrid.BackColor = System.Drawing.Color.CornflowerBlue;
            btnLoadGrid.FlatAppearance.BorderColor = System.Drawing.Color.CornflowerBlue;
            btnLoadGrid.FlatAppearance.BorderSize = 0;
            btnLoadGrid.FlatStyle = FlatStyle.Flat;
            btnLoadGrid.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnLoadGrid.Location = new System.Drawing.Point(32, 44);
            btnLoadGrid.Name = "btnLoadGrid";
            btnLoadGrid.Size = new System.Drawing.Size(105, 29);
            btnLoadGrid.TabIndex = 1;
            btnLoadGrid.Text = "Load Grid";
            btnLoadGrid.UseVisualStyleBackColor = false;
            btnLoadGrid.Click += btnLoadGrid_Click;
            // 
            // advancedDataGridView1
            // 
            advancedDataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            advancedDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            advancedDataGridView1.FilterAndSortEnabled = true;
            advancedDataGridView1.FilterStringChangedInvokeBeforeDatasourceUpdate = true;
            advancedDataGridView1.Location = new System.Drawing.Point(0, 125);
            advancedDataGridView1.Name = "advancedDataGridView1";
            advancedDataGridView1.RightToLeft = RightToLeft.No;
            advancedDataGridView1.RowTemplate.Height = 25;
            advancedDataGridView1.Size = new System.Drawing.Size(800, 325);
            advancedDataGridView1.SortStringChangedInvokeBeforeDatasourceUpdate = true;
            advancedDataGridView1.TabIndex = 2;
            // 
            // InitialTime
            // 
            InitialTime.Anchor = AnchorStyles.Top;
            InitialTime.Location = new System.Drawing.Point(215, 30);
            InitialTime.Name = "InitialTime";
            InitialTime.Size = new System.Drawing.Size(123, 23);
            InitialTime.TabIndex = 3;
            // 
            // btnFilterID
            // 
            btnFilterID.Anchor = AnchorStyles.Top;
            btnFilterID.BackColor = System.Drawing.Color.CornflowerBlue;
            btnFilterID.FlatAppearance.BorderSize = 0;
            btnFilterID.FlatStyle = FlatStyle.Flat;
            btnFilterID.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnFilterID.Location = new System.Drawing.Point(370, 67);
            btnFilterID.Name = "btnFilterID";
            btnFilterID.Size = new System.Drawing.Size(75, 29);
            btnFilterID.TabIndex = 5;
            btnFilterID.Text = "Filter";
            btnFilterID.UseVisualStyleBackColor = false;
            btnFilterID.Click += btnFilterID_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Top;
            btnClear.BackColor = System.Drawing.Color.CornflowerBlue;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            btnClear.Location = new System.Drawing.Point(487, 67);
            btnClear.Name = "btnClear";
            btnClear.Size = new System.Drawing.Size(75, 29);
            btnClear.TabIndex = 6;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // FinalTime
            // 
            FinalTime.Anchor = AnchorStyles.Top;
            FinalTime.Location = new System.Drawing.Point(216, 59);
            FinalTime.Name = "FinalTime";
            FinalTime.Size = new System.Drawing.Size(122, 23);
            FinalTime.TabIndex = 7;
            // 
            // searchID
            // 
            searchID.Anchor = AnchorStyles.Top;
            searchID.ForeColor = System.Drawing.Color.Black;
            searchID.Location = new System.Drawing.Point(361, 33);
            searchID.Name = "searchID";
            searchID.Size = new System.Drawing.Size(100, 23);
            searchID.TabIndex = 8;
            // 
            // searchSSR
            // 
            searchSSR.Anchor = AnchorStyles.Top;
            searchSSR.ForeColor = System.Drawing.Color.Black;
            searchSSR.Location = new System.Drawing.Point(487, 33);
            searchSSR.Name = "searchSSR";
            searchSSR.Size = new System.Drawing.Size(100, 23);
            searchSSR.TabIndex = 9;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(171, 33);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(38, 15);
            label1.TabIndex = 11;
            label1.Text = "From:";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(187, 67);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(22, 15);
            label2.TabIndex = 12;
            label2.Text = "To:";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top;
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(238, 9);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(75, 15);
            label3.TabIndex = 13;
            label3.Text = "Time Interval";
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Location = new System.Drawing.Point(385, 9);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(60, 15);
            label4.TabIndex = 14;
            label4.Text = "Aircraft ID";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(497, 9);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(81, 15);
            label5.TabIndex = 15;
            label5.Text = "Track Number";
            // 
            // expCSVbtn
            // 
            expCSVbtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            expCSVbtn.BackColor = System.Drawing.Color.CornflowerBlue;
            expCSVbtn.FlatAppearance.BorderSize = 0;
            expCSVbtn.FlatStyle = FlatStyle.Flat;
            expCSVbtn.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            expCSVbtn.Location = new System.Drawing.Point(647, 33);
            expCSVbtn.Name = "expCSVbtn";
            expCSVbtn.Size = new System.Drawing.Size(130, 27);
            expCSVbtn.TabIndex = 16;
            expCSVbtn.Text = "Export CSV";
            expCSVbtn.UseVisualStyleBackColor = false;
            expCSVbtn.Click += expCSVbtn_Click;
            // 
            // formDisplay
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(expCSVbtn);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(searchSSR);
            Controls.Add(searchID);
            Controls.Add(FinalTime);
            Controls.Add(btnClear);
            Controls.Add(btnFilterID);
            Controls.Add(InitialTime);
            Controls.Add(advancedDataGridView1);
            Controls.Add(btnLoadGrid);
            FormBorderStyle = FormBorderStyle.None;
            Name = "formDisplay";
            Text = "formDisplay";
            Load += formDisplay_Load;
            ((System.ComponentModel.ISupportInitialize)advancedDataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button btnLoadGrid;
        private Zuby.ADGV.AdvancedDataGridView advancedDataGridView1;
        private TextBox InitialTime;
        private Button btnFilterID;
        private Button btnClear;
        private TextBox FinalTime;
        private TextBox searchID;
        private TextBox searchSSR;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Button expCSVbtn;
    }
}