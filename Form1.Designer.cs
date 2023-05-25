namespace KeywordCrawler
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
            label1 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            checkBox1 = new CheckBox();
            listBox1 = new ListBox();
            label3 = new Label();
            button1 = new Button();
            textBox2 = new TextBox();
            numericUpDown1 = new NumericUpDown();
            label4 = new Label();
            checkBox2 = new CheckBox();
            button2 = new Button();
            label5 = new Label();
            statusDisplay = new Label();
            resultsDataGridView = new DataGridView();
            startCrawlBtn = new Button();
            exactMatchCheckBox = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(46, 38);
            label1.Margin = new Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new Size(278, 45);
            label1.TabIndex = 0;
            label1.Text = "Keyword Crawler";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(138, 101);
            textBox1.Margin = new Padding(2, 1, 2, 1);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(574, 39);
            textBox1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(79, 101);
            label2.Margin = new Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new Size(55, 32);
            label2.TabIndex = 2;
            label2.Text = "URL";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Checked;
            checkBox1.Location = new Point(138, 152);
            checkBox1.Margin = new Padding(2, 1, 2, 1);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(439, 36);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Always use secure connection (https)";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // listBox1
            // 
            listBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            listBox1.FormattingEnabled = true;
            listBox1.ItemHeight = 32;
            listBox1.Location = new Point(30, 427);
            listBox1.Margin = new Padding(2, 1, 2, 1);
            listBox1.Name = "listBox1";
            listBox1.Size = new Size(275, 516);
            listBox1.TabIndex = 4;
            listBox1.SelectedIndexChanged += listBox1_SelectedIndexChanged_1;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label3.Location = new Point(30, 272);
            label3.Margin = new Padding(2, 0, 2, 0);
            label3.Name = "label3";
            label3.Size = new Size(133, 32);
            label3.TabIndex = 5;
            label3.Text = "Keywords:";
            // 
            // button1
            // 
            button1.Location = new Point(30, 360);
            button1.Margin = new Padding(2, 1, 2, 1);
            button1.Name = "button1";
            button1.Size = new Size(77, 46);
            button1.TabIndex = 6;
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(30, 319);
            textBox2.Margin = new Padding(2, 1, 2, 1);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(275, 39);
            textBox2.TabIndex = 7;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(1054, 154);
            numericUpDown1.Margin = new Padding(2, 1, 2, 1);
            numericUpDown1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(135, 39);
            numericUpDown1.TabIndex = 8;
            numericUpDown1.Value = new decimal(new int[] { 100, 0, 0, 0 });
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(728, 154);
            label4.Margin = new Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.Size = new Size(322, 32);
            label4.TabIndex = 9;
            label4.Text = "Delay between requests (ms)";
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(1232, 157);
            checkBox2.Margin = new Padding(2, 1, 2, 1);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(297, 36);
            checkBox2.TabIndex = 10;
            checkBox2.Text = "Include periodic pauses";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button2.Location = new Point(1603, 253);
            button2.Name = "button2";
            button2.Size = new Size(163, 51);
            button2.TabIndex = 11;
            button2.Text = "Export CSV";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(350, 274);
            label5.Margin = new Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new Size(102, 32);
            label5.TabIndex = 12;
            label5.Text = "Results:";
            // 
            // statusDisplay
            // 
            statusDisplay.AutoSize = true;
            statusDisplay.Location = new Point(481, 267);
            statusDisplay.Margin = new Padding(2, 0, 2, 0);
            statusDisplay.Name = "statusDisplay";
            statusDisplay.Size = new Size(0, 32);
            statusDisplay.TabIndex = 13;
            // 
            // resultsDataGridView
            // 
            resultsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            resultsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsDataGridView.Location = new Point(347, 319);
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.RowHeadersVisible = false;
            resultsDataGridView.RowHeadersWidth = 82;
            resultsDataGridView.RowTemplate.Height = 41;
            resultsDataGridView.Size = new Size(1419, 624);
            resultsDataGridView.TabIndex = 14;
            resultsDataGridView.CellContentClick += resultsDataGridView_CellContentClick;
            // 
            // startCrawlBtn
            // 
            startCrawlBtn.Location = new Point(727, 97);
            startCrawlBtn.Margin = new Padding(2, 1, 2, 1);
            startCrawlBtn.Name = "startCrawlBtn";
            startCrawlBtn.Size = new Size(148, 46);
            startCrawlBtn.TabIndex = 15;
            startCrawlBtn.Text = "Start Crawl";
            startCrawlBtn.UseVisualStyleBackColor = true;
            startCrawlBtn.Click += startCrawlBtn_Click;
            // 
            // exactMatchCheckBox
            // 
            exactMatchCheckBox.AutoSize = true;
            exactMatchCheckBox.Checked = true;
            exactMatchCheckBox.CheckState = CheckState.Checked;
            exactMatchCheckBox.Location = new Point(138, 192);
            exactMatchCheckBox.Name = "exactMatchCheckBox";
            exactMatchCheckBox.Size = new Size(238, 36);
            exactMatchCheckBox.TabIndex = 16;
            exactMatchCheckBox.Text = "Whole words only";
            exactMatchCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1799, 974);
            Controls.Add(exactMatchCheckBox);
            Controls.Add(startCrawlBtn);
            Controls.Add(resultsDataGridView);
            Controls.Add(statusDisplay);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(checkBox2);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(textBox2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(listBox1);
            Controls.Add(checkBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Keyword Crawler";
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBox1;
        private Label label2;
        private CheckBox checkBox1;
        private ListBox listBox1;
        private Label label3;
        private Button button1;
        private TextBox textBox2;
        private NumericUpDown numericUpDown1;
        private Label label4;
        private CheckBox checkBox2;
        private Button button2;
        private Label label5;
        private Label statusDisplay;
        private DataGridView resultsDataGridView;
        private Button startCrawlBtn;
        private CheckBox exactMatchCheckBox;
    }
}